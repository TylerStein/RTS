using UnityEngine;
using System.Collections;

namespace RTS2.Input
{
    public interface IInteractionEvent<T>
    {
        T[] GetEventTargets();
        T GetEventTarget();
        InteractionState GetInteractionState();
    }

    public class InteractionEvent<T> : IInteractionEvent<T>
    {
        T[] eventTargets;
        InteractionState interactionState;

        public InteractionEvent(T[] targets, InteractionState state) {
            eventTargets = targets;
            interactionState = state;
        }

        public InteractionEvent(T target, InteractionState state) {
            eventTargets = new T[1];
            eventTargets[0] = target;
            interactionState = state;
        }

        public T[] GetEventTargets() {
            return eventTargets;
        }

        public T GetEventTarget() {
            return eventTargets[0];
        }

        public InteractionState GetInteractionState() {
            return interactionState;
        }
    }
}
