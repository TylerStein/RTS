namespace RTS.Entities
{
    class EntityFactory
    {
        public static Entity BuildingEntity(string _displayName, Building _building)
        {
            Entity entity = new Entity(EntityType.building, _displayName);
            entity.building = _building;
            return entity;
        }

        public static Entity ResourceEntity(string _displayName, Resource _resource)
        {
            Entity entity = new Entity(EntityType.resource, _displayName);
            entity.resource = _resource;
            return entity;
        }

        public static Entity UnitEntity(string _displayName, Unit _unit)
        {
            Entity entity = new Entity(EntityType.resource, _displayName);
            entity.unit = _unit;
            return entity;
        }
    }
}
