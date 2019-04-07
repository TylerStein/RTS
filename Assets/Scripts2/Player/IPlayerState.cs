using UnityEngine;
using RTS2.Entity;
namespace RTS2.Player
{ 
    public interface IPlayerState
    {
        IEntitySelectionHandler GetEntitySelectionHandler();
    }
}
