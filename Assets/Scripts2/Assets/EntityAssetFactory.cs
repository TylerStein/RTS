using UnityEngine;
using System.Collections.Generic;

namespace RTS2.Assets
{
    public class EntityAssetFactory : MonoBehaviour
    {
        [SerializeField] protected EntityManifest entityManifest;
        
        public ICollection<string> GetAssetNamesOfType(EAssetType assetType) {
            switch (assetType) {
                case EAssetType.PROP: return entityManifest.GetPropNames();
                case EAssetType.UNIT: return entityManifest.GetUnitNames();
                case EAssetType.RESOURCE: return entityManifest.GetResourceNames();
                case EAssetType.BUILDING: return entityManifest.GetBuildingNames();
                default: throw new UnityException("No Prefab Dictionary exists for Asset Type " + assetType.ToString());
            }
        }

        public GameObject GetAssetPrefab(EAssetType assetType, string assetIdentifier) {
            switch (assetType) {
                case EAssetType.PROP: return entityManifest.GetPropPrefab(assetIdentifier);
                case EAssetType.UNIT: return entityManifest.GetUnitPrefab(assetIdentifier);
                case EAssetType.RESOURCE: return entityManifest.GetResourcePrefab(assetIdentifier);
                case EAssetType.BUILDING: return entityManifest.GetBuildingPrefab(assetIdentifier);
                default: throw new UnityException("No Prefab Dictionary exists for Asset Type " + assetType.ToString());
            }
        }
    }
}
