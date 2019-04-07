using UnityEngine;
namespace RTS2.Input
{
    public interface IPositionInteractionEvent
    {
        Vector3 GetPosition();
        IInteractionState GetInteractionState();
    }
}