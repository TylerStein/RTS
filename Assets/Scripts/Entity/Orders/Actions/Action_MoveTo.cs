using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.Orders {
    public class Action_MoveTo : OrderAction
    {
        public Vector3 destination;

        public Action_MoveTo(Vector3 _destination, Order _order) : base(_order) {
            destination = _destination;
        }

        public override string GetDesctiptor() {
            return string.Format("Order (type={0}, destination={1})", order.orderType.ToString(), destination.ToString());
        }

        public override void Execute() {
            isComplete = false;
            isExecuted = true;
            order.entity.unit.navMeshAgent.SetDestination(destination);
        }

        public override void Update() {
			if (!isComplete) {
				if (Vector3.Distance(order.entity.unit.navMeshAgent.destination, order.entity.unit.transform.position) <= order.entity.unit.navMeshAgent.stoppingDistance) {
					if (!order.entity.unit.navMeshAgent.hasPath || order.entity.unit.navMeshAgent.velocity.sqrMagnitude == 0f) {
						isComplete = true;
					}
				}
			}
        }

        public override void Cancel() {
            isComplete = true;
            isExecuted = false;
        }
    }
}