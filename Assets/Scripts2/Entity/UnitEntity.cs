using UnityEngine;

using RTS2.Assets;
using RTS2.Entity.Behaviour;

namespace RTS2.Entity
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