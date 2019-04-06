using System.Collections.Generic;
using UnityEngine;
using RTS.Orders;

namespace RTS.Entities
{
    public class EntityDriver : MonoBehaviour
    {
        public GameObject prefab_arrow_move;

        public Queue<Order> orders;
        public OrderPool orderPool;
        public Queue<GameObject> orderIndicators;

        public Entity entity;

        public void AddOrder(Order order)
        {
            if (order.orderType == OrderType.move)
            {
                AddIndicator(((Action_MoveTo)order.action).destination, prefab_arrow_move);
            }
            entity.entityDriver.orders.Enqueue(order);
            entity.owner.UIContext.UpdateEntityOrders(entity);
        }

        public void CancelOrders()
        {
            while (orders.Count > 0)
            {
                entity.entityDriver.orders.Dequeue().Cancel();
            }

            while (orderIndicators.Count > 0)
            {
                Destroy(entity.entityDriver.orderIndicators.Dequeue());
            }
            entity.owner.UIContext.UpdateEntityOrders(entity);
        }

        public void ReplaceOrders(Order order)
        {
            CancelOrders();
            AddOrder(order);
        }

        public void ClearLastIndicator()
        {
            Destroy(orderIndicators.Dequeue());
        }

        public void AddIndicator(Vector3 dest, GameObject prefab)
        {
            orderIndicators.Enqueue(Instantiate(prefab, dest, prefab_arrow_move.transform.rotation));
        }

        public void Start()
        {
            orders = new Queue<Order>();
            orderIndicators = new Queue<GameObject>();
            if (!prefab_arrow_move) prefab_arrow_move = PrefabLoader.GetMoveArrow();
        }

        public void Update()
        {
            if (orders.Count > 0)
            {
                Order currentOrder = orders.Peek();
                if (!currentOrder.action.isExecuted)
                {
                    Debug.Log("Executing Order " + currentOrder.action.GetDesctiptor());
                    currentOrder.Execute();
                }
                currentOrder.Update();
                if (currentOrder.action.isComplete)
                {
                    Debug.Log("Completed Order " + currentOrder.action.GetDesctiptor());
                    orders.Dequeue();
                    entity.owner.UIContext.UpdateEntityOrders(entity);
                    if (currentOrder.orderType == OrderType.move)
                    {
                        ClearLastIndicator();
                    }
                }
            }
        }
    }
}
