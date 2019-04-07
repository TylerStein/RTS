using UnityEngine;
using System.Collections;
using RTS2.Entity;

namespace RTS2.Player
{
    public class BasicPlayerState : MonoBehaviour, IPlayerState
    {
        [SerializeField] private int playerIndex;
        [SerializeField] private Component entitySelectionHandler;

        public int GetPlayerIndex() {
            return playerIndex;
        }
        public IEntitySelectionHandler GetEntitySelectionHandler() {
            return (IEntitySelectionHandler)entitySelectionHandler;
        }
    }
}