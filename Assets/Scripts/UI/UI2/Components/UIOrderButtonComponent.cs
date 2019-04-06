using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using RTS.Orders;
using RTS.Entities;

namespace RTS.UI.Components
{
    public class UIOrderButtonComponent : MonoBehaviour, IPointerClickHandler
    {
        public OrderDefinition orderDefinition;
        public Entity entity;

        public Text label;

        private string labelText;

        public void SetContent(OrderDefinition _order, Entity _entity)
        {
            orderDefinition = _order;
            entity = _entity;
            UpdateDisplay();
        }

        public void ClearContent()
        {
            orderDefinition = new OrderDefinition();
            entity = null;
            labelText = "";
            label.text = labelText;
        }

        public void OverrideLabel(string text)
        {
            labelText = text;
            label.text = labelText;
        }

        public void UpdateDisplay()
        {
            labelText = orderDefinition.orderName;
            label.text = labelText;
        }

        void IPointerClickHandler.OnPointerClick(PointerEventData eventData)
        {
            
            if (orderDefinition.orderType != OrderType.unset)
            {
                Debug.Log("Clicked UIOrderButtonComponent with Order " + orderDefinition.orderName);
                entity.owner.OrderController.SelectedOrder = orderDefinition;
            } else
            {
                Debug.Log("Clicked UIOrderButtonComponent with Null Order");
            }
        }

        public void SetSelected() {
            label.text = "(" + labelText + ")";
        }

        public void SetUnselected() {
            label.text = labelText;
        }
    }
}
