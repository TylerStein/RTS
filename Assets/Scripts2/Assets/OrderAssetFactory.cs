using UnityEngine;
using System.Collections.Generic;

using RTS2.Orders;
namespace RTS2.Assets
{
    public class OrderAssetFactory : MonoBehaviour
    {
        [SerializeField] protected OrderManifest orderManifest;

        public OrderBehaviour GetOrder(string orderIdentifier) {
            return orderManifest.GetOrder(orderIdentifier);
        }

        public ICollection<string> GetOrderNames() {
            return orderManifest.GetOrderNames();
        }
    }
}
