using UnityEngine;
using RTS2.SerializedTypes;
using System.Collections.Generic;

using RTS2.Orders;
namespace RTS2.Assets
{
    [CreateAssetMenu(fileName = "New Orders Manifest", menuName = "RTS2/Manifest/Orders Manifest")]
    public class OrderManifest : ScriptableObject
    {
        [SerializeField] protected SerializedOrderDictionary orderDictionary;

        internal OrderBehaviour GetOrder(string orderIdentifier) {
            return orderDictionary[orderIdentifier];
        }

        internal ICollection<string> GetOrderNames() {
            return orderDictionary.Keys;
        }
    }
}