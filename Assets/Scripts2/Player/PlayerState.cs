using UnityEngine;
using System.Collections;
using RTS2.Entities;

namespace RTS2.Player
{
    /// <summary>
    ///     Holds player state data and classes
    /// </summary>
    public class PlayerState : MonoBehaviour
    {
        [SerializeField] private int playerIndex;
        [SerializeField] private EntitySelectionHandler entitySelectionHandler;

        public EntitySelectionHandler EntitySelectionHandler {
            get { return entitySelectionHandler; }
        }

        public int GetPlayerIndex() {
            return playerIndex;
        }
    }
}