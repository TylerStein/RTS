using UnityEngine;

using RTS2.Assets;
using RTS2.Entities.Behaviours;

namespace RTS2.Entities
{
    public class UnitEntity : Entity
    {
        public override EAssetType GetAssetType() {
            return EAssetType.UNIT;
        }
        
        public override string GetEntityName() {
            return "Generic Unit";
        }
    }
}