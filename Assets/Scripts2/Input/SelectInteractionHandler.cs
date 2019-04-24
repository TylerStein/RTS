using UnityEngine;
using RTS2.Player;
using RTS2.Entities;
namespace RTS2.Input
{
    [RequireComponent(typeof(PlayerState))]
    class SelectInteractionHandler : MonoBehaviour
    {
        [SerializeField] private PlayerState playerState;

        public void OnEntityInteraction(InteractionEvent<Entity> interactionEvent) {
            InteractionState interactionState = interactionEvent.GetInteractionState();
            EntitySelectionHandler selectionHandler = playerState.EntitySelectionHandler;

            if (interactionState.GetInputType() == EInputType.PRIMARY) {
                if (interactionState.GetInputModifier() == EInputModifier.MULTI) {
                    // Add to Selection
                    selectionHandler.AddSelectedEntities(interactionEvent.GetEventTargets());
                } else if (interactionState.GetInputModifier() == EInputModifier.NONE) {
                    // Replace Selection
                    selectionHandler.SetSelectedEntities(interactionEvent.GetEventTargets());
                }
            } else if (interactionState.GetInputType() == EInputType.SECONDARY) {
                if (interactionState.GetInputModifier() == EInputModifier.MULTI) {
                    // Add to Action
                    selectionHandler.AddActionTargetEntities(interactionEvent.GetEventTargets());
                } else if (interactionState.GetInputModifier() == EInputModifier.NONE) {
                    // Replace Action
                    selectionHandler.SetActionTargetEntities(interactionEvent.GetEventTargets());
                }
            }
        }

        public void OnPositionInteraction(InteractionEvent<Vector3> interactionEvent) {
            InteractionState interactionState = interactionEvent.GetInteractionState();
            EntitySelectionHandler selectionHandler = playerState.EntitySelectionHandler;

            if (interactionState.GetInputType() == EInputType.PRIMARY) {
                selectionHandler.ClearSelectedEntities();
            } else if (interactionState.GetInputType() == EInputType.SECONDARY) {
                if (interactionState.GetInputModifier() == EInputModifier.MULTI) {
                    // Add to Action
                    selectionHandler.AddActionTargetLocation(interactionEvent.GetEventTarget());
                } else if (interactionState.GetInputModifier() == EInputModifier.NONE) {
                    // Replace Action
                    selectionHandler.SetActionTargetLocation(interactionEvent.GetEventTarget());
                }
            }
        }
    }
}
