using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RTS2.Entity;
namespace RTS2.Input
{
    public class CursorInput : MonoBehaviour
    {
        public Component interactionConsumer;
        public CursorCameraInput cursorCameraInput;

        bool primaryDown = false;
        bool secondaryDown = false;
        bool modifierDown = false;
        
        private void Update() {
                primaryDown = UnityEngine.Input.GetButtonDown("Primary");
                secondaryDown = UnityEngine.Input.GetButtonDown("Secondary");
                modifierDown = UnityEngine.Input.GetButtonDown("Shift");

                if (primaryDown) {
                    RaycastHit hit;
                    if (cursorCameraInput.Raycast(out hit)) {
                        InteractionState interactionState = new InteractionState(modifierDown ? EInputModifier.MULTI : EInputModifier.NONE, EInputType.PRIMARY);
                        IEntity hitEntity = hit.collider.gameObject.GetComponent<IEntity>();
                        if (hitEntity != null) {
                            InteractionEvent<IEntity> interactionEvent = new InteractionEvent<IEntity>(hitEntity, interactionState);
                            ((IInteractionConsumer)interactionConsumer).ConsumeEntityInteraction(interactionEvent);
                        } else {
                            InteractionEvent<Vector3> interactionEvent = new InteractionEvent<Vector3>(hit.point, interactionState);
                            ((IInteractionConsumer)interactionConsumer).ConsumePositionInteraction(interactionEvent);
                        }

                    }
                } else if (secondaryDown) {
                    RaycastHit hit;
                    if (cursorCameraInput.Raycast(out hit)) {
                        InteractionState interactionState = new InteractionState(modifierDown ? EInputModifier.MULTI : EInputModifier.NONE, EInputType.SECONDARY);
                        IEntity hitEntity = hit.collider.gameObject.GetComponent<IEntity>();
                        if (hitEntity != null) {
                            InteractionEvent<IEntity> interactionEvent = new InteractionEvent<IEntity>(hitEntity, interactionState);
                            ((IInteractionConsumer)interactionConsumer).ConsumeEntityInteraction(interactionEvent);
                        } else {
                            InteractionEvent<Vector3> interactionEvent = new InteractionEvent<Vector3>(hit.point, interactionState);
                            ((IInteractionConsumer)interactionConsumer).ConsumePositionInteraction(interactionEvent);
                        }

                    }
                }
            }
        }
}