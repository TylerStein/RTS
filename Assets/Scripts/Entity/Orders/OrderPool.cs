using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.Orders {
    [RequireComponent(typeof(Entity))]
    public class OrderPool : MonoBehaviour
    {
        public List<OrderDefinition> availableOrders = new List<OrderDefinition>();
        public Entity entity;
        public OrderManager orderController;

        // Start is called before the first frame update
        void Awake()
        {
            entity = GetComponent<Entity>();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public OrderDefinition[] GetOrdersArray()
        {
            return availableOrders.ToArray();
        }
    }
}