using UnityEngine;

using RTS2.Player;
namespace RTS2.Input
{
    public class EntityInteractionConsumer : MonoBehaviour, IInteractionConsumer
    {
        public Component playerState;

        public void ConsumePositionInteraction(IPositionInteractionEvent positionInteractionEvent) {
            IInteractionState interactionState = positionInteractionEvent.GetInteractionState();
            IEntitySelectionHandler selectionHandler = ((IPlayerState)playerState).GetEntitySelectionHandler();

            if (interactionState.GetInputType() == EInputType.PRIMARY) {
                selectionHandler.ClearSelectedEntities();
            } else if (interactionState.GetInputType() == EInputType.SECONDARY) {
                if (interactionState.GetInputModifier() == EInputModifier.MULTI) {
                    // Add to Action
                    selectionHandler.AddActionTargetLocation(positionInteractionEvent.GetPosition());
                } else if (interactionState.GetInputModifier() == EInputModifier.NONE) {
                    // Replace Action
                    selectionHandler.SetActionTargetLocation(positionInteractionEvent.GetPosition());
                }
            }
        }

        public void ConsumeEntityInteraction(IEntityInteractionEvent entityInteractionEvent) {
            IInteractionState interactionState = entityInteractionEvent.GetInteractionState();
            IEntitySelectionHandler selectionHandler = ((IPlayerState)playerState).GetEntitySelectionHandler();

            if (interactionState.GetInputType() == EInputType.PRIMARY) {
                if (interactionState.GetInputModifier() == EInputModifier.MULTI) {
                    // Add to Selection
                    selectionHandler.AddSelectedEntities(entityInteractionEvent.GetEntities());
                } else if (interactionState.GetInputModifier() == EInputModifier.NONE) {
                    // Replace Selection
                    selectionHandler.SetSelectedEntities(entityInteractionEvent.GetEntities());
                }
            } else if (interactionState.GetInputType() == EInputType.SECONDARY) {
                if (interactionState.GetInputModifier() == EInputModifier.MULTI) {
                    // Add to Action
                    selectionHandler.AddActionTargetEntities(entityInteractionEvent.GetEntities());
                } else if (interactionState.GetInputModifier() == EInputModifier.NONE) {
                    // Replace Action
                    selectionHandler.SetActionTargetEntities(entityInteractionEvent.GetEntities());
                }
            }
        }
    }
}