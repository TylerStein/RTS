using UnityEngine;
using System.Collections.Generic;
using RTS2.Entity;
namespace RTS2.Player
{
    public interface IEntitySelectionHandler
    {
        IEntity GetSelectedEntity(int index = 0);
        List<IEntity> GetSelectedEntities();

        void ClearSelectedEntities();
        void SetSelectedEntities(IEntity[] entities);
        void AddSelectedEntities(IEntity[] entities);

        void SetActionTargetLocation(Vector3 location);
        void AddActionTargetLocation(Vector3 location);

        void SetActionTargetEntities(IEntity[] entities);
        void AddActionTargetEntities(IEntity[] entities);
    }
}