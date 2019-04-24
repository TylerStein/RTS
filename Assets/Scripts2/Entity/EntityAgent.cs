using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

using RTS2.Orders;
namespace RTS2.Entities {
    [System.Serializable]
    public class OrderState
    {
        [SerializeField] public OrderBehaviour behaviour;
        [SerializeField] public OrderContext context;

        public OrderState(OrderBehaviour orderBehaviour, OrderContext orderContext) {
            behaviour = orderBehaviour;
            context = orderContext;
        }
    }

    [RequireComponent(typeof(Entity))]
    public class EntityAgent : MonoBehaviour
    {
        [SerializeField] protected NavMeshAgent navMeshAgent;
        public NavMeshAgent NavMeshAgent { get { return navMeshAgent; } }

        [SerializeField] protected List<OrderState> activeOrders = new List<OrderState>();
        public List<OrderState> ActiveOrders { get { return activeOrders; } }

        public void ReceiveOrder(OrderBehaviour orderBehaviour, OrderContext context) {
            context.agent = this;
            activeOrders.Add(new OrderState(orderBehaviour, context));
        }

        public void Update() {
            if (activeOrders.Count > 0) {
                OrderState orderState = activeOrders[0];
                if (!orderState.context.hasExecuted) {
                    orderState.behaviour.Execute(orderState.context);
                }

                bool complete = orderState.behaviour.UpdateBehaviour(orderState.context);
                if (complete) activeOrders.RemoveAt(0);
            }
        }
    }
}