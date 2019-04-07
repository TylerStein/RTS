using UnityEngine;
using System.Collections;
using RTS2.Entity;

namespace RTS2.Player
{
    public class BasicPlayerState : MonoBehaviour, IPlayerState
    {
        public Component entitySelectionHandler;

        public IEntitySelectionHandler GetEntitySelectionHandler() {
            return (IEntitySelectionHandler)entitySelectionHandler;
        }
    }
}