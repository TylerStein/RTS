
using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using RTS2.Entities.Behaviours;
using RTS2.Assets;

namespace RTS2.Entities
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] protected int playerIndex;
        [SerializeField] protected List<EntityBehaviour> entityBehaviours;

        public virtual void Start() {
            for (int i = 0; i < entityBehaviours.Count; i++) {
                entityBehaviours[i].Initialize();
            }
        }

        public virtual void SetActionTargetEntities(Entity[] entities) {
            for (int i = 0; i < entityBehaviours.Count; i++) {
                entityBehaviours[i].OnSetActionTargetEntities(entities);
            }
        }

        public virtual void SetActionTargetLocation(Vector3 location) {
            for (int i = 0; i < entityBehaviours.Count; i++) {
                entityBehaviours[i].OnSetActionTargetLocation(location);
            }
        }

        public virtual void SetSelected() {
            for (int i = 0; i < entityBehaviours.Count; i++) {
                entityBehaviours[i].OnPrimarySelect();
            }
        }

        public virtual void UnsetSelected() {
            for (int i = 0; i < entityBehaviours.Count; i++) {
                entityBehaviours[i].OnPrimaryUnselect();
            }
        }

        public EntityBehaviour GetBehaviour(System.Type behaviourType) {
           for (int i = 0; i < entityBehaviours.Count; i++) {
                if (entityBehaviours[i].GetType() == behaviourType) return entityBehaviours[i];
           }
            throw new UnityException("Entity does not have behaviour of type " + behaviourType);
        }

        public List<BehaviourDependency> GetBehaviourDependencies() {
            List<BehaviourDependency> dependencies = new List<BehaviourDependency>();
            for (int i = 0; i < entityBehaviours.Count; i++) {
                BehaviourDependency[] behaviourDependencies = entityBehaviours[i].GetDependencies();
                for (int j = 0; j < behaviourDependencies.Length; j++) {
                    if (!dependencies.Contains(behaviourDependencies[j])) {
                        dependencies.Add(behaviourDependencies[j]);
                    }
                }
            }

            return dependencies;
        }

        public void AssertBehaviourDependencies() {
            List<BehaviourDependency> dependencies = GetBehaviourDependencies();
            for (int i = 0; i < dependencies.Count; i++) {
                for (int j = 0; j < entityBehaviours.Count; j++) {
                    if (entityBehaviours[j].GetType() == dependencies[i].behaviourType) break;
                }

                throw new UnityException("Entity does not meet dependency of type " + entityBehaviours[i].GetType());
            }
        }

        public virtual string GetEntityName() {
            return name;
        }

        public virtual EAssetType GetAssetType() {
            return EAssetType.NULL;
        }

        public virtual GameObject GetGameObject() {
            return gameObject;
        }

        public virtual int GetOwningPlayerIndex() {
            return -1;
        }

        public virtual void SetOwningPlayerIndex(int index) {
            playerIndex = index;
        }

        public virtual string GetAssetName() {
            return "NULL";
        }

        public virtual void AddActionTargetEntities(Entity[] entities) {
            //
        }

        public virtual void AddActionTargetLocation(Vector3 location) {
            //
        }
    }
}