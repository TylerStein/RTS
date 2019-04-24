using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using RTS2.Assets;
using RTS2.Player;
using RTS2.Entities;
using RTS2.Input;
using RTS2.Orders;
namespace RTS2.UI {
    public class ContextActionsButtonList : MonoBehaviour
    {
        public GameObject buttonPrefab;
        public RectTransform container;

        public EntitySelectionHandler entitySelectionHandler;
        public InteractionEventConsumer interactionEventConsumer;

        public OrderAssetFactory orderAssetFactory;
        public EntityOrdersFactory entityOrdersFactory;
        public EntityAssetFactory entityAssetFactory;

        public List<GameObject> orderButtons = new List<GameObject>();

        public void OnEntitySelected(string entityAssetName) {
            ICollection<string> entityOrderNames = entityOrdersFactory.GetOrdersForEntity(entityAssetName);
            foreach (string name in entityOrderNames) addOrderButton(name);
        }

        public void ClearButtons() {
            foreach (GameObject obj in orderButtons) Destroy(obj);
            orderButtons.Clear();
        }

        public void OnSelectOrder(string orderName) {
            OrderBehaviour selectedOrder = orderAssetFactory.GetOrder(orderName);
            Entity activeEntity = entitySelectionHandler.GetSelectedEntity();

            if (selectedOrder && activeEntity) interactionEventConsumer.SetOrderMode(activeEntity, selectedOrder);
            else throw new UnityException("Missing order or selected entity!");
        }

        private void addOrderButton(string orderName) {
            GameObject buttonObject = Instantiate(buttonPrefab, container);
            Button button = buttonObject.GetComponent<Button>();
            Text text = buttonObject.GetComponentInChildren<Text>();
            text.text = orderName;
            button.onClick.AddListener(() => {
                OnSelectOrder(orderName);
            });
            orderButtons.Add(buttonObject);
        }
    }
}