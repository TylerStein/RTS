using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Orders;
using UnityEngine.UI;
using RTS.UI.Components;
using RTS.Entities;

namespace RTS.UI.Views
{
    public class UIOrderActionsView : MonoBehaviour
    {
        public List<UIOrderButtonComponent> orderButtonComponents = new List<UIOrderButtonComponent>();

        public void SetAvailableOrders(OrderPool orderPool)
        {
            orderButtonComponents.ForEach(button => button.ClearContent());

            if (orderPool != null) {
                int orderListLength = orderPool.availableOrders.Count;

                for (int i = 0; i < orderListLength; i++)
                {
                    if (i < orderButtonComponents.Count)
                    {
                        orderButtonComponents[i].SetContent(orderPool.availableOrders[i], orderPool.entity);
                    }
                }
            }
        }

        public void SetSelectedOrder(OrderDefinition definition) {
            for (int i = 0; i < orderButtonComponents.Count; i++) {
                if (definition.orderType != OrderType.unset && orderButtonComponents[i].orderDefinition == definition) {
                    orderButtonComponents[i].SetSelected();
                } else {
                    orderButtonComponents[i].SetUnselected();
                }
            }
        }

        //public Order ResolveOrder(OrderType type, Entity entity)
        //{
        //    if (type == OrderType.spawn)
        //    {
        //        Debug.Log("Creating spawn fanatic order");
        //        Order newOrder = new Order(entity, OrderType.spawn);
        //        newOrder.action = new Action_Spawn(entity, PrefabLoader.GetFanatic(), newOrder);
        //        return newOrder;
        //    } else if (type == OrderType.move) {
        //        Order newOrder = new 
        //    }
        //    else return null;
        //}
    }
}
