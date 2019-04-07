using RTS2.Assets;
using UnityEngine;
namespace RTS2.Entity
{
    public interface IEntity
    {
        void SetSelected();
        void UnsetSelected();
        string GetEntityName();
        EAssetType GetAssetType();
        GameObject GetGameObject();
        int GetOwningPlayerIndex();
        void SetOwningPlayerIndex(int index);

        void SetActionTargetEntities(IEntity[] entities);
        void SetActionTargetLocation(Vector3 location);
        void AddActionTargetEntities(IEntity[] entities);
        void AddActionTargetLocation(Vector3 location);
    }
}