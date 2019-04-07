using UnityEngine;
using System.Collections;

using RTS2.Assets;
namespace RTS2.Entity
{
    public class PropEntity : MonoBehaviour, IEntity
    {
        [SerializeField] string entityName = "Generic Prop";
        [SerializeField] bool isSelected = false;
        [SerializeField] int playerIndex;

        public void AddActionTargetEntities(IEntity[] entities) {
            //
        }

        public void AddActionTargetLocation(Vector3 location) {
            //
        }

        public EAssetType GetAssetType() {
            return EAssetType.PROP;
        }

        public int GetOwningPlayerIndex() {
            return playerIndex;
        }

        public void SetOwningPlayerIndex(int index) {
            playerIndex = index;
        }

        public string GetEntityName() {
            return entityName;
        }

        public GameObject GetGameObject() {
            return gameObject;
        }

        public void Select() {
            isSelected = true;
        }

        public void SetActionTargetEntities(IEntity[] entities) {
            //
        }

        public void SetActionTargetLocation(Vector3 location) {
            //
        }

        public void SetSelected() {
            isSelected = true;
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }

        public void UnsetSelected() {
            isSelected = false;
            gameObject.GetComponent<Renderer>().material.color = Color.white;
        }
    }
}