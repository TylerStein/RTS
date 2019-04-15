using UnityEngine;
using RTS2.Orders;
namespace RTS2.Assets
{
    [System.Serializable]
    public struct OrderDefinition
    {
        [SerializeField] public Order order;
        [SerializeField] public MetaOrder metaOrder;
    }
}