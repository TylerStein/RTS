using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using System.Collections.Generic;

using RTS2.Entities;
using RTS2.Assets;
using RTS2.Input;
namespace RTS2.UI {
    public class DevMenu : MonoBehaviour
    {
        [SerializeField] private EntityAssetFactory assetFactory;
        [SerializeField] private AssetButtonList labelledButtonList;
        [SerializeField] private InteractionEventConsumer interactionConsumer;

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
            interactionConsumer.SetPlacementMode(prefab);

            //if (prefab) {
            //    Vector3 location = new Vector3(Random.Range(-10f, 10f), 0.5f, Random.Range(-10f, 10f));
            //    Debug.Log(string.Format("Attempting to spawn {0}.{1} at {2}", assetType.ToString(), name, location.ToString()));

            //    NavMeshHit navMeshHit;
            //    if (NavMesh.SamplePosition(location, out navMeshHit, 25.0f, -1)) {
            //        Vector3 spawnLocation = navMeshHit.position;

            //        GameObject worldObject = Instantiate(prefab, spawnLocation, prefab.transform.rotation);
            //        Entity entity = worldObject.GetComponent<Entity>();
            //        entity.SetOwningPlayerIndex(0);
            //    }
                
            //} else {
            //    Debug.LogWarning(string.Format("Failed to Spawn {0}.{1}", assetType.ToString(), name));
            //}
        }
    }
}