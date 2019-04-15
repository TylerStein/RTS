using UnityEngine;

namespace RTS2.Entities.Behaviours
{
    public struct BehaviourDependency
    {
        public System.Type behaviourType;
    }

    [HideInInspector]
    public abstract class EntityBehaviour : MonoBehaviour
    {
        protected BehaviourDependency[] behaviourDependencies;

        protected EntityBehaviour(BehaviourDependency[] dependencies) {
            behaviourDependencies = dependencies;
        }

        protected EntityBehaviour() {
            behaviourDependencies = new BehaviourDependency[0];
        }

        [SerializeField] protected Entity entity;
        public Entity Entity {
            get { return entity; }
        }

        public BehaviourDependency[] GetDependencies() {
            return behaviourDependencies;
        }

        public virtual void OnPrimarySelect() {
            //
        }

        public virtual void OnPrimaryUnselect() {
            //
        }

        public virtual void OnSetActionTargetEntities(Entity[] entities) {
            //
        }

        public virtual void OnSetActionTargetLocation(Vector3 location) {
            //
        }
    }
}