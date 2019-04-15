using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

using RTS2.Entities;
using RTS2.Assets;
namespace RTS2.UI {
    public class DevMenu : MonoBehaviour
    {
        [SerializeField] private EntityAssetFactory assetFactory;
        [SerializeField] private AssetButtonList labelledButtonList;

        private void Start() {
            if (labelledButtonList && assetFactory) {
                labelledButtonList.ClearButtons();
                List<string> propNames = new List<string>(assetFactory.GetAssetNamesOfType(EAssetType.PROP));
                for (int i = 0; i < propNames.Count; i++) {
                    labelledButtonList.AddButton(EAssetType.PROP, propNames[i]);
                }
                labelledButtonList.onClick.AddListener(OnClickAsset);
            }
        }
  
        ICollection<string> GetDisplayNamesForType(EAssetType assetType) {
            return assetFactory.GetAssetNamesOfType(assetType);
        }

        void OnClickAsset(EAssetType assetType, string name) {
            GameObject prefab = assetFactory.GetAssetPrefab(assetType, name);
            if (prefab) {
                Debug.Log(string.Format("Spawning {0}.{1}", assetType.ToString(), name));
                Vector3 location = new Vector3(Random.Range(-5f, 5f), 0.5f, Random.Range(-5f, 5f));
                GameObject worldObject = Instantiate(prefab, location, prefab.transform.rotation);
                Entity entity = worldObject.GetComponent<Entity>();
                entity.SetOwningPlayerIndex(0);
            } else {
                Debug.LogWarning(string.Format("Failed to Spawn {0}.{1}", assetType.ToString(), name));
            }
        }
    }
}