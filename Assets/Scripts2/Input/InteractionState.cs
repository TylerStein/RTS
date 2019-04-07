using UnityEngine;
using System.Collections;

namespace RTS2.Input {
public class InteractionState : IInteractionState
    {
        private EInputModifier inputModifier;
        private EInputType inputType;

        public InteractionState(EInputModifier inputModifier, EInputType inputType) {
            this.inputModifier = inputModifier;
            this.inputType = inputType;
        }

        public void SetInputModifier(EInputModifier inputModifier) {
            this.inputModifier = inputModifier;
        }

        public EInputModifier GetInputModifier() {
            return inputModifier;
        }

        public EInputType GetInputType() {
            return inputType;
        }
    }
}