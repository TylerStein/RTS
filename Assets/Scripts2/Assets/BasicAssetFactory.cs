using UnityEngine;
using System.Collections.Generic;
using RotaryHeart.Lib.SerializableDictionary;

namespace RTS2.Assets
{
    [System.Serializable]
    public class GameObjectDictionary : SerializableDictionaryBase<string, GameObject> { }

    public class BasicAssetFactory : MonoBehaviour, IAssetFactory
    {
        [SerializeField] private GameObjectDictionary propDictionary;
        [SerializeField] private GameObjectDictionary unitDictionary;
        [SerializeField] private GameObjectDictionary resourceDictionary;
        [SerializeField] private GameObjectDictionary buildingDictionary;

        public GameObject GetAssetPrefab(EAssetType assetType, string assetIdentifier) {
            return GetDictionary(assetType)[assetIdentifier];
        }

        public ICollection<string> GetAssetNamesOfType(EAssetType assetType) {
            return GetDictionary(assetType).Keys;
        }

        public GameObjectDictionary GetDictionary(EAssetType assetType) {
            switch (assetType) {
                case EAssetType.PROP: return propDictionary;
                case EAssetType.UNIT: return unitDictionary;
                case EAssetType.RESOURCE: return resourceDictionary;
                case EAssetType.BUILDING: return resourceDictionary;
                default: throw new UnityException("No Prefab Dictionary exists for Asset Type " + assetType.ToString());
            }
        }
    }
}
