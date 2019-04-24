using UnityEngine;

using RTS2.Entities;
using RTS2.Orders;
namespace RTS2.Input
{
    public enum EInteractionMode
    {
        select = 0,
        place = 1,
        order = 2
    }

    /// <summary>
    ///     Binds input events with interaction handlers
    /// </summary>
    public class InteractionEventConsumer : MonoBehaviour
    {
        [SerializeField] private EInteractionMode interactionMode;

        [SerializeField] private SelectInteractionHandler selectHandler;
        [SerializeField] private PlaceInteractionHandler placeHandler;
        [SerializeField] private OrderInteractionHandler orderHandler;

        void Awake() {
            interactionMode = EInteractionMode.select;    
        }

        public void SetPlacementMode(GameObject entityPrefab) {
            if (interactionMode != EInteractionMode.place) CancelCurrentInteractionMode();
            Entity e = entityPrefab.GetComponent<Entity>();
            GameObject ghostPrefab = e.GetGhostPrefab();
            interactionMode = EInteractionMode.place;
            placeHandler.SetActive(entityPrefab, ghostPrefab);
        }

        public void SetOrderMode(Entity entity, OrderBehaviour order) {
            if (interactionMode != EInteractionMode.order) CancelCurrentInteractionMode();
            interactionMode = EInteractionMode.order;
            orderHandler.SetActive(entity, order);
        }

        public void SetSelectMode() {
            if (interactionMode != EInteractionMode.select) CancelCurrentInteractionMode();
            interactionMode = EInteractionMode.select;
        }

        public void SetWorldCursor(Vector3 position) {
            if (interactionMode == EInteractionMode.place) placeHandler.SetWorldCursor(position);
            else if (interactionMode == EInteractionMode.order) orderHandler.SetWorldCursor(position);
        }

        public void CancelCurrentInteractionMode() {
            switch (interactionMode) {
                case EInteractionMode.place:
                    placeHandler.Cancel();
                    break;
                case EInteractionMode.order:
                    orderHandler.Cancel();
                    break;
            }
        }

        public void ConsumeEntityInteraction(InteractionEvent<Entity> interaction) {
            switch(interactionMode) {
                case EInteractionMode.select:
                    selectHandler.OnEntityInteraction(interaction);
                    break;
                case EInteractionMode.place:
                    placeHandler.OnEntityInteraction(interaction);
                    break;
                case EInteractionMode.order:
                    orderHandler.OnEntityInteraction(interaction);
                    break;
            }
        }

        public void ConsumePositionInteraction(InteractionEvent<Vector3> interaction) {
            switch (interactionMode) {
                case EInteractionMode.select:
                    selectHandler.OnPositionInteraction(interaction);
                    break;
                case EInteractionMode.place:
                    placeHandler.OnPositionInteraction(interaction);
                    break;
                case EInteractionMode.order:
                    orderHandler.OnPositionInteraction(interaction);
                    break;
            }
        }
    }
}