using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;
using RTS.Orders;
using RTS.UI.Views;
using UnityEngine.Events;

namespace RTS.UI
{
    public class UIContextActionCards : MonoBehaviour
    {
        public UIOrderActionsView orderActionsView;
        private Entity contextEntity;
        private UnityEvent orderEvent;

        public void SetContextEntity(Entity ctx) {
            contextEntity = ctx;
            orderActionsView.SetAvailableOrders(contextEntity.entityDriver.orderPool);

            if (orderEvent == null) {
                orderEvent = new UnityEvent();
                orderEvent.AddListener(OnChangeSelectedOrder);
                contextEntity.owner.OrderController.SetOrderChangeListener(orderEvent);
            } else {
                orderEvent.RemoveAllListeners();
                orderEvent.AddListener(OnChangeSelectedOrder);
            }
        }

        public void ClearContextEntity() {
            orderActionsView.SetAvailableOrders(null);
            orderActionsView.SetSelectedOrder(new OrderDefinition());
            contextEntity.owner.OrderController.RemoveOrderChangeListener();
            orderEvent.RemoveAllListeners();
            orderEvent = null;
            contextEntity = null;
        }

        public void OnChangeSelectedOrder() {
            orderActionsView.SetSelectedOrder(contextEntity.owner.OrderController.SelectedOrder);
            Debug.Log("OnChangeSelectedOrder " + contextEntity.owner.OrderController.SelectedOrder);
            // contextEntity.entityDriver.AddOrder()
        }
    }
}
