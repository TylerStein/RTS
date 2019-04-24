
using UnityEngine;
using System.Collections;

using System.Collections.Generic;
using RTS2.Entities.Behaviours;
using RTS2.Assets;
using RTS2.Orders;

namespace RTS2.Entities
{
    public class Entity : MonoBehaviour
    {
        [SerializeField] protected string entityAssetName = "NULL";
        [SerializeField] protected int playerIndex;
        // [SerializeField] protected List<EntityBehaviour> entityBehaviours;

        [SerializeField] protected GameObject ghostPrefab;
        [SerializeField] protected EntitySelectionBehaviour selectionBehaviour;
        [SerializeField] protected EntityAgent entityAgent;

        [SerializeField] protected OrderBehaviour defaultOrderBehaviour;

        [SerializeField] new private Renderer renderer;

        public virtual void Start() {
            renderer = GetComponent<Renderer>();
        }

        public virtual void SetActionTargetEntities(Entity[] entities) {
            if (defaultOrderBehaviour) {
                OrderContext ctx = defaultOrderBehaviour.CreateContext(entityAgent, entities);
                entityAgent.ReceiveOrder(defaultOrderBehaviour, ctx);
            }
        }

        public virtual void SetActionTargetLocation(Vector3 location) {
            if (defaultOrderBehaviour) {
                OrderContext ctx = defaultOrderBehaviour.CreateContext(entityAgent, location);
                entityAgent.ReceiveOrder(defaultOrderBehaviour, ctx);
            }
        }

        public virtual void SetSelected() {
            selectionBehaviour.OnPrimarySelect(renderer);
        }

        public virtual void UnsetSelected() {
            selectionBehaviour.OnPrimaryUnselect(renderer);
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
            return entityAssetName;
        }

        public GameObject GetGhostPrefab() {
            return ghostPrefab;
        }

        public virtual void AddActionTargetEntities(Entity[] entities) {
            if (defaultOrderBehaviour) {
                OrderContext ctx = defaultOrderBehaviour.CreateContext(entityAgent, entities);
                entityAgent.ReceiveOrder(defaultOrderBehaviour, ctx);
            }
        }

        public virtual void AddActionTargetLocation(Vector3 location) {
            if (defaultOrderBehaviour) {
                OrderContext ctx = defaultOrderBehaviour.CreateContext(entityAgent, location);
                entityAgent.ReceiveOrder(defaultOrderBehaviour, ctx);
            }
        }

        public virtual void ReceiveOrder(OrderBehaviour order, OrderContext context) {
            if (entityAgent) entityAgent.ReceiveOrder(order, context);
        }
    }
}