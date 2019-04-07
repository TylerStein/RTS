using UnityEngine;
using System.Collections;

namespace RTS2.Input
{
    public interface IInteractionConsumer
    {
        void ConsumeEntityInteraction(IEntityInteractionEvent entityInteractionEvent);
    }
}