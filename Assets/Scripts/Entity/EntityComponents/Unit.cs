using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using RTS.Orders;

namespace RTS.Entities {
	public class Unit : EntityComponent {
		public NavMeshAgent navMeshAgent;

		public Color focusColor = Color.green;
		public Material material;

		private Color baseColor = Color.white;

		public void Start() {
			material = GetComponent<MeshRenderer>().material;
			baseColor = material.color;
			if (entity) this.entity.owner.UnitManager.AddUnit(this);
		}

		public void Update() {
			
		}


		public override void OnFocus(InteractionManager manager) {
            material.color = focusColor;
            entity.owner.OrderController.SelectedOrder = entity.entityDriver.orderPool.availableOrders[0];
            // entity.owner.UIController.SetValue("C_ORDERS", entity.entityDriver.orderPool.GetOrdersArray());
        }

		public override void OnUnfocus(InteractionManager manager) {
            entity.owner.OrderController.SelectedOrder = new OrderDefinition();
			material.color = baseColor;
		}

		public override void OnSecondaryClickEntity(Entity thing, Vector3 point, bool additive = false) {
			if (thing && thing.transform) {
				List<Order> orders = ResolveOrder(entity, new ClickContext(thing.gameObject, point));
				
				if (additive) orders.ForEach(order => entity.entityDriver.AddOrder(order));
				else orders.ForEach(order => entity.entityDriver.ReplaceOrders(order));
			}
		}

		public override void OnSecondaryClickOther(GameObject other, Vector3 point, bool additive = false) {
				List<Order> orders = ResolveOrder(entity, new ClickContext(other, point));
            if (additive) orders.ForEach(order => entity.entityDriver.AddOrder(order));
            else {
                entity.entityDriver.CancelOrders();
                orders.ForEach(order => entity.entityDriver.AddOrder(order));
            }
        }

        public override void OnAssignOrder(Order order, bool additive = false) {
            if (additive) entity.entityDriver.AddOrder(order);
            else entity.entityDriver.ReplaceOrders(order);
        }

        public static new List<Order> ResolveOrder(Entity entity, ClickContext context)
        {
            List<Order> output = new List<Order>();
            if (context.hasObject) {
                Entity thing = context.Thing.GetComponent<Entity>();
                if (thing == null) {
                    if (context.hasPoint) output.Add(OrderFactory.CreateMoveOrder(entity, context.Point));
                    else output.Add(OrderFactory.CreateMoveOrder(entity, context.Thing.transform.position));
                } else {
                    switch (thing.entityType) {
                        case EntityType.unit:
                            output.Add(OrderFactory.CreateMoveOrder(entity, thing.transform.position));
                            break;
                        case EntityType.resource:
                            output.Add(OrderFactory.CreateResourceOrder(entity, thing));
                            break;
                        default:
                            throw new UnityException(string.Format("Requested order on an unrecognized interactable type: {0}", thing.entityType));
                    }
                }
            } else if (context.hasPoint) {
               output.Add(OrderFactory.CreateMoveOrder(entity, context.Point));
            } else throw new UnityException(string.Format("GetOrder called without a valid context: {0}", context));

            return output;
        }
	}
}