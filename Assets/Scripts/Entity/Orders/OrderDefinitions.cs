using UnityEngine;
using RTS.Entities;

namespace RTS.Orders
{
    [CreateAssetMenu(fileName = "Order Definition", menuName = "Orders", order = 1)]
    public class OrderDefinition : ScriptableObject
    {
        [SerializeField] public OrderType orderType;
        [SerializeField] public IOrderData orderData;

        public string orderName;
        public OrderDefinition() {
            orderName = "Null Order";
            orderType = OrderType.unset;
        }
  
    }

    public interface IOrderData
    {
        OrderType GetOrderType();
    }

    [CreateAssetMenu(fileName = "Move Order", menuName = "OrderTypes", order = 1)]
    public class MoveOrderDefinition : ScriptableObject, IOrderData
    {
        [SerializeField] public Vector3 moveTarget;
        public OrderType GetOrderType() {
            return OrderType.move;
        }
    }

    [CreateAssetMenu(fileName = "Build Order", menuName = "OrderTypes", order = 2)]
    public class BuildOrderDefinition : ScriptableObject, IOrderData
    {
        [SerializeField] public Entity buildEntity;
        public Vector3 buildLocation;
        public OrderType GetOrderType() {
            return OrderType.build;
        }
    }

    [CreateAssetMenu(fileName = "Collect Order", menuName = "OrderTypes", order = 3)]
    public class CollectOrderDefenition : ScriptableObject, IOrderData
    {
        [SerializeField] public Entity engageTarget;
        public OrderType GetOrderType() {
            return OrderType.collect;
        }
    }

    [CreateAssetMenu(fileName = "Spawn Order", menuName = "OrderTypes", order = 4)]
    public class SpawnOrderDefinition : ScriptableObject, IOrderData
    {
        [SerializeField] public Entity spawnEntity;
        public OrderType GetOrderType() {
            return OrderType.spawn;
        }
    }

    [CreateAssetMenu(fileName = "Attack Order", menuName = "OrderTypes", order = 5)]
    public class AttackOrderDefinition : ScriptableObject, IOrderData
    {
        [SerializeField] public Entity targetEntity;
        public OrderType GetOrderType() {
            return OrderType.attack;
        }
    }
}
