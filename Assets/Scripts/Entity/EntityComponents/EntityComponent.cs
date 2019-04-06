using UnityEngine;
using System.Collections.Generic;
using RTS.Orders;

namespace RTS.Entities {
    public abstract class EntityComponent : MonoBehaviour {
        public Entity entity;

        public abstract void OnFocus(InteractionManager manager);
        public abstract void OnUnfocus(InteractionManager manager);
        public abstract void OnSecondaryClickEntity(Entity thing, Vector3 point, bool additive = false);
        public abstract void OnSecondaryClickOther(GameObject other, Vector3 pointer, bool additive = false);
        public abstract void OnAssignOrder(Order order, bool additive = false);
        public static List<Order> ResolveOrder(Entity entity, ClickContext context)
        {
            return new List<Order>();
        }
    }
}