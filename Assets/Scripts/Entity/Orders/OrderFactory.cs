using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.Orders {
	public class OrderFactory {
		public static Order CreateMoveOrder(Entity entity, Vector3 location) {
			Order newOrder = new Order(entity, OrderType.move);
			newOrder.action = new Action_MoveTo(location, newOrder);
            Debug.Log("Creating moveOrder for entity named " + entity.displayName);
			return newOrder;
		}

		public static Order CreateResourceOrder(Entity entity, Entity target) {
			Order newOrder = new Order(entity, OrderType.collect);
			newOrder.action = new Action_Gather(target, newOrder);
            Debug.Log("Creating gatherOrder for entity named " + entity.displayName);
			return newOrder;
		}

		public static Order CreateSpawnOrder(Entity entity, GameObject prefab) {
			Order newOrder = new Order(entity, OrderType.spawn);
			newOrder.action = new Action_Spawn(entity, prefab, newOrder);
            Debug.Log("Creating spawnOrder for entity named " + entity.displayName);
			return newOrder;
		}

        public static Order CreateEmptyOrder(Entity entity)
        {
            Order newOrder = new Order(entity, OrderType.unset);
            newOrder.action = new OrderAction(newOrder);
            Debug.Log("Creating emptyOrder for entity named " + entity.displayName);
            return newOrder;
        }
	}
}