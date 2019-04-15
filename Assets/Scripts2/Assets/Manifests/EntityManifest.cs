using UnityEngine;
using System.Collections.Generic;
using RTS2.SerializedTypes;
namespace RTS2.Assets
{
    [CreateAssetMenu(fileName = "New Entity Manifest", menuName = "Manifest/Entity Manifest")]
    public class EntityManifest : ScriptableObject
    {
        [SerializeField] protected SerializedGameObjectDictionary propDictionary;
        [SerializeField] protected SerializedGameObjectDictionary unitDictionary;
        [SerializeField] protected SerializedGameObjectDictionary resourceDictionary;
        [SerializeField] protected SerializedGameObjectDictionary buildingDictionary;

        public GameObject GetPropPrefab(string entityIdentifier) {
            return propDictionary[entityIdentifier];
        }

        public ICollection<string> GetPropNames() {
            return propDictionary.Keys;
        }

        public GameObject GetUnitPrefab(string entityIdentifier) {
            return unitDictionary[entityIdentifier];
        }

        public ICollection<string> GetUnitNames() {
            return unitDictionary.Keys;
        }

        public GameObject GetResourcePrefab(string entityIdentifier) {
            return resourceDictionary[entityIdentifier];
        }

        public ICollection<string> GetResourceNames() {
            return resourceDictionary.Keys;
        }

        public GameObject GetBuildingPrefab(string entityIdentifier) {
            return buildingDictionary[entityIdentifier];
        }

        public ICollection<string> GetBuildingNames() {
            return buildingDictionary.Keys;
        }
    }
}