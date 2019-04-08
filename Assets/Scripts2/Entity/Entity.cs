using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using RTS2.Entity.Behaviour;
using RTS2.Assets;

namespace RTS2.Entity
{
    public class Entity : MonoBehaviour, IEntity
    {
        [SerializeField] protected int playerIndex;
        [SerializeField] protected List<EntityBehaviour> entityBehaviours;

        public virtual void SetActionTargetEntities(IEntity[] entities) {
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

        public virtual BehaviourDependency[] GetBehaviourDependencies() {
            return new BehaviourDependency[0];
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

        public virtual void AddActionTargetEntities(IEntity[] entities) {
            //
        }

        public virtual void AddActionTargetLocation(Vector3 location) {
            //
        }
    }
}