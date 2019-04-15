using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using RTS2.Entities;
namespace RTS2.Input
{
    /// <summary>
    ///     Resolves interaction for passing to an interaction consumer
    /// </summary>
    public class CursorInput : MonoBehaviour
    {
        public InteractionConsumer interactionConsumer;
        public CursorCameraInput cursorCameraInput;

        private bool primaryDown = false;
        public bool PrimaryDown { get { return primaryDown; } }

        private bool secondaryDown = false;
        public bool SecondaryDown { get { return secondaryDown; } }

        private bool modifierDown = false;
        public bool ModifierDown { get { return modifierDown; } }

        private Vector3 cursorPosition = Vector2.zero;
        public Vector3 CursorPosition {  get { return cursorPosition; } }

        private void Update() {
            cursorPosition = UnityEngine.Input.mousePosition;
                primaryDown = UnityEngine.Input.GetButtonDown("Primary");
                secondaryDown = UnityEngine.Input.GetButtonDown("Secondary");
                modifierDown = UnityEngine.Input.GetButtonDown("Shift");

                if (primaryDown) {
                    RaycastHit hit;
                    if (cursorCameraInput.Raycast(out hit)) {
                        InteractionState interactionState = new InteractionState(modifierDown ? EInputModifier.MULTI : EInputModifier.NONE, EInputType.PRIMARY);
                        Entity hitEntity = hit.collider.gameObject.GetComponent<Entity>();
                        if (hitEntity != null) {
                            InteractionEvent<Entity> interactionEvent = new InteractionEvent<Entity>(hitEntity, interactionState);
                            interactionConsumer.ConsumeEntityInteraction(interactionEvent);
                        } else {
                            InteractionEvent<Vector3> interactionEvent = new InteractionEvent<Vector3>(hit.point, interactionState);
                            interactionConsumer.ConsumePositionInteraction(interactionEvent);
                        }

                    }
                } else if (secondaryDown) {
                    RaycastHit hit;
                    if (cursorCameraInput.Raycast(out hit)) {
                        InteractionState interactionState = new InteractionState(modifierDown ? EInputModifier.MULTI : EInputModifier.NONE, EInputType.SECONDARY);
                        Entity hitEntity = hit.collider.gameObject.GetComponent<Entity>();
                        if (hitEntity != null) {
                            InteractionEvent<Entity> interactionEvent = new InteractionEvent<Entity>(hitEntity, interactionState);
                            interactionConsumer.ConsumeEntityInteraction(interactionEvent);
                        } else {
                            InteractionEvent<Vector3> interactionEvent = new InteractionEvent<Vector3>(hit.point, interactionState);
                            interactionConsumer.ConsumePositionInteraction(interactionEvent);
                        }

                    }
                }
            }
        }
}