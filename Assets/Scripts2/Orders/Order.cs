using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

using RTS2.Entities;
namespace RTS2.Orders
{
    [CreateAssetMenu(fileName = "New Order", menuName = "Orders/New Order", order = 2)]
    public class Order : ScriptableObject
    {
        [SerializeField] string orderName;
        [SerializeField] MetaOrder metaOrder;
        [SerializeField] OrderBehaviour orderBehaviour;
    }
}