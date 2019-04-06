using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.Orders {
	public class Order {
		public Sprite orderSprite;
		public OrderType orderType;
		
		public OrderAction action;
        public OrderDefinition orderDefinition;

		public Entity entity;

		public Order(Entity _entity, OrderType _type) {
			entity = _entity;
			orderType = _type;
		}

		public void Execute() {
			action.Execute();
		}
		public void Update() {
			action.Update();
		}
		public void Cancel() {
			action.Cancel();
		}

        public Order Copy()
        {
            Order newOrder = new Order(entity, orderType);
            newOrder.action = action;
            return newOrder;
        }
	}
}