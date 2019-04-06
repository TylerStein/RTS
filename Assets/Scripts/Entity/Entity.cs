using UnityEngine;

namespace RTS.Entities {
	public class Entity : MonoBehaviour
    {
		public string displayName;
		public EntityType entityType;
		public Sprite entitySprite;
		
		public Player owner;

		public Building building = null;
		public Resource resource = null;
		public Unit unit = null;

        public EntityDriver entityDriver;

		public Entity(EntityType _entityType, string _displayName) {
			displayName = _displayName;
			entityType = _entityType;
		}
		
		public void OnFocus(InteractionManager manager) {
			ResolveEntityComponent().OnFocus(manager);
		}

		public void OnUnfocus(InteractionManager manager) {
			ResolveEntityComponent().OnUnfocus(manager);

		}
		public void OnSecondaryClickEntity(Entity thing, Vector3 point, bool additive = false) {
			ResolveEntityComponent().OnSecondaryClickEntity(thing, point, additive);
		}

		public void OnSecondaryClickOther(GameObject other, Vector3 point, bool additive = false) {
			ResolveEntityComponent().OnSecondaryClickOther(other, point, additive);
		}

        public void OnAssignOrder(Orders.Order order, bool additive = false) {
            ResolveEntityComponent().OnAssignOrder(order, additive);
        }

		private EntityComponent ResolveEntityComponent() {
			switch (entityType) {
				case EntityType.unit: return unit;
				case EntityType.resource: return resource;
				case EntityType.building: return building;
				default: throw new UnityException("ResolveEntityComponent called with an invalid entityType. Either the value is not set or the type has not been accounted for.");
			}
		}
	}
}