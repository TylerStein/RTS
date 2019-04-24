using UnityEngine;
using UnityEngine.AI;
using RTS2.Entities;
using RTS2.Player;
using RTS2.Orders;
namespace RTS2.Input
{
    class OrderInteractionHandler : MonoBehaviour
    {
        [SerializeField] public float maxSnapToNavMeshDistance = 1.0f;
        [SerializeField] public int navMeshAreaMask = -1;

        [SerializeField] private PlayerState playerState;
        [SerializeField] private InteractionEventConsumer interactionConsumer;

        [SerializeField] private GameObject indicatorObject;
        [SerializeField] private IndicatorController indicatorController;
        [SerializeField] private GameObject indicatorPrefab;

        public OrderBehaviour order;
        public Entity entity;

        private bool active = false;
        private bool validPlacement = false;
        private Vector3 lastValidPosition = Vector3.zero;
  
        public void SetWorldCursor(Vector3 cursorPosition) {
            if (active && indicatorObject) {
                Vector3 ghostPosition = cursorPosition;
                bool isValid = FindNearestValidPosition(cursorPosition, out ghostPosition);
                if (isValid) {
                    indicatorObject.transform.position = ghostPosition;
                    if (!validPlacement) {
                        validPlacement = true;
                        indicatorController.SetValid();
                    }
                } else {
                    indicatorObject.transform.position = cursorPosition;
                    if (validPlacement) {
                        validPlacement = false;
                        indicatorController.SetInvalid();
                    }
                }

            }
        }

        public void OnEntityInteraction(InteractionEvent<Entity> interactionEvent) {
            EntityAgent agent = entity.GetComponent<EntityAgent>();
            if (agent != null) {
                Entity e = interactionEvent.GetEventTarget();
                OrderContext ctx = order.CreateContext(agent, e);
                agent.ReceiveOrder(order, ctx);
            }
        }

        public void OnPositionInteraction(InteractionEvent<Vector3> interactionEvent) {
            Vector3 position = interactionEvent.GetEventTarget();
            EntityAgent agent = entity.GetComponent<EntityAgent>();
            if (agent != null) {
                OrderContext ctx = order.CreateContext(agent, position);
                agent.ReceiveOrder(order, ctx);
            }
        }

        public void SetActive(Entity entity, OrderBehaviour order) {
            if (active) Cancel();
            this.order = order;
            this.entity = entity;
            indicatorObject = Instantiate(indicatorPrefab, Vector3.zero, indicatorPrefab.transform.rotation);
            indicatorController = indicatorObject.GetComponent<IndicatorController>();
            active = true;
        }

        public void Cancel() {
            active = false;
            if (indicatorObject) Destroy(indicatorObject);
            indicatorObject = null;
            indicatorController = null;
        }

        public bool FindNearestValidPosition(Vector3 testPosition, out Vector3 adjustedPosition) {
            NavMeshHit hit;
            if (NavMesh.SamplePosition(testPosition, out hit, maxSnapToNavMeshDistance, navMeshAreaMask)) {
                adjustedPosition = hit.position;
                lastValidPosition = adjustedPosition;
                return true;
            }

            adjustedPosition = lastValidPosition;
            return false;
        }
    }
}
