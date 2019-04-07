using UnityEngine;

using RTS2.Player;
using RTS2.Entity;
namespace RTS2.Input
{
    public class EntityInteractionConsumer : MonoBehaviour, IInteractionConsumer
    {
        public Component playerState;

        public void ConsumePositionInteraction(IInteractionEvent<Vector3> interactionEvent) {
            IInteractionState interactionState = interactionEvent.GetInteractionState();
            IEntitySelectionHandler selectionHandler = ((IPlayerState)playerState).GetEntitySelectionHandler();

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

        public void ConsumeEntityInteraction(IInteractionEvent<IEntity> interactionEvent) {
            IInteractionState interactionState = interactionEvent.GetInteractionState();
            IEntitySelectionHandler selectionHandler = ((IPlayerState)playerState).GetEntitySelectionHandler();

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
    }
}