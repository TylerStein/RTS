using UnityEngine;
using System.Collections.Generic;

using RTS2.Orders;
namespace RTS2.Assets
{
    public class OrderAssetFactory : MonoBehaviour
    {
        [SerializeField] protected OrderManifest orderManifest;

        public Order GetOrder(string orderIdentifier) {
            return GetOrderDefinition(orderIdentifier).order;
        }

        public MetaOrder GetMetaOrder(string orderIdentifier) {
            return GetOrderDefinition(orderIdentifier).metaOrder;
        }

        public OrderDefinition GetOrderDefinition(string orderIdentifier) {
            return orderManifest.GetOrderDefinition(orderIdentifier);
        }

        public ICollection<string> GetOrderNames() {
            return orderManifest.GetOrderNames();
        }
    }
}
