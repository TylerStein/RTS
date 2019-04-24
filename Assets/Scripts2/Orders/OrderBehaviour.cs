using UnityEngine;

using RTS2.Entities;
namespace RTS2.Orders
{
    public enum EOrderTargetType
    {
        NULL = 0,
        VECTOR3 = 1,
        ENTITY = 2,
        ENTITYLIST = 3
    }

    [System.Serializable]
    public abstract class OrderContext
    {
        [SerializeField] public bool hasExecuted;
        [SerializeField] public EntityAgent agent;
        [SerializeField] public bool isComplete;

        [SerializeField] public Vector3 targetPosition;
        [SerializeField] public Entity targetEntity;
        [SerializeField] public Entity[] targetEntities;

        [SerializeField] public EOrderTargetType targetType;

        public OrderContext() {
            targetType = EOrderTargetType.NULL;
            isComplete = false;
            hasExecuted = false;
        }

        public OrderContext(EntityAgent agent, Entity target) {
            this.agent = agent;
            targetEntity = target;
            targetType = EOrderTargetType.ENTITY;

            isComplete = false;
            hasExecuted = false;
        }

        public OrderContext(EntityAgent agent, Entity[] target) {
            this.agent = agent;
            targetEntities = target;
            targetType = EOrderTargetType.ENTITYLIST;

            isComplete = false;
            hasExecuted = false;
        }

        public OrderContext(EntityAgent agent, Vector3 position) {
            this.agent = agent;
            targetPosition = position;
            targetType = EOrderTargetType.VECTOR3;

            isComplete = false;
            hasExecuted = false;
        }
    }

    [System.Serializable]
    public class NullOrderContext : OrderContext
    {
        public NullOrderContext() : base() {
            //
        }
    }

    public abstract class OrderBehaviour : ScriptableObject {
        [SerializeField] string behaviourName;

        protected OrderBehaviour(string behaviourName = "NULL") {
            this.behaviourName = behaviourName;
        }

        public virtual bool IsValidTarget(EntityAgent agent, Entity e) {
            return true;
        }

        public virtual bool IsValidTarget(EntityAgent agent, Entity[] e) {
            return true;
        }

        public virtual bool IsValidTarget(EntityAgent agent, Vector3 position) {
            return true;
        }

        public virtual OrderContext CreateContext(EntityAgent agent, Vector3 target) {
            return new NullOrderContext();
        }

        public virtual OrderContext CreateContext(EntityAgent angent, Entity target) {
            return new NullOrderContext();
        }

        public virtual OrderContext CreateContext(EntityAgent agent, Entity[] target) {
            return new NullOrderContext();
        }

        public virtual void Execute(OrderContext context) {
            context.hasExecuted = true;
            context.isComplete = true;
        }

        public virtual bool UpdateBehaviour(OrderContext context) {
            if (context.isComplete == true) return true;
            return false;
        }

        public virtual void Cancel(OrderContext context) {
            context.isComplete = true;
        }
    }
}