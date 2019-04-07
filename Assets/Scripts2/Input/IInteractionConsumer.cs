using UnityEngine;
using System.Collections;

using RTS2.Entity;
namespace RTS2.Input
{
    public interface IInteractionConsumer
    {
        void ConsumeEntityInteraction(IInteractionEvent<IEntity> interactionEvent);
        void ConsumePositionInteraction(IInteractionEvent<Vector3> interactionEvent);
    }
}