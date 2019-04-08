using UnityEngine;

namespace RTS2.Entity.Behaviour
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

        [SerializeField] protected Component entity;
        public IEntity Entity {
            get { return ((IEntity)entity); }
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

        public virtual void OnSetActionTargetEntities(IEntity[] entities) {
            //
        }

        public virtual void OnSetActionTargetLocation(Vector3 location) {
            //
        }
    }
}