using RTS2.Entity;

namespace RTS2.Input
{
    public interface IEntityInteractionEvent
    {
        IEntity[] GetEntities();
        IInteractionState GetInteractionState();
    }
}