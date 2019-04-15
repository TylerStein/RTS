using UnityEngine;
using System.Collections.Generic;

namespace RTS2.Assets
{
    public class EntityOrdersFactory : MonoBehaviour
    {
        [SerializeField] protected EntityOrdersManifest entityOrdersManifest;

        public ICollection<string> GetOrdersForEntity(string entityIdentifier) {
            return entityOrdersManifest.GetEntityOrders(entityIdentifier);
        }
    }
}