using UnityEngine;
using System.Collections.Generic;

using RTS2.Entities;
namespace RTS2.Player
{
    public class EntitySelectionHandler : MonoBehaviour
    {
        private List<Entity> selectedEntities = new List<Entity>();

        public Entity GetSelectedEntity(int index = 0) {
            if (selectedEntities.Count >= index) throw new UnityException("EntityIndexOutOfBouns: There is no entity at index " + index + "!");
            else return selectedEntities[index];
        }

        public List<Entity> GetSelectedEntities() {
            return selectedEntities;
        }

        public void AddActionTargetEntities(Entity[] entities) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].AddActionTargetEntities(entities);
            }
        }

        public void AddActionTargetLocation(Vector3 location) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].AddActionTargetLocation(location);
            }
        }

        public void AddSelectedEntities(Entity[] entities) {
            for (int i = 0; i < entities.Length; i++) {
                entities[i].SetSelected();
            }
            selectedEntities.AddRange(entities);
        }

        public void ClearSelectedEntities() {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].UnsetSelected();
            }
            selectedEntities.Clear();
        }

        public void SetActionTargetEntities(Entity[] entities) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].SetActionTargetEntities(entities);
            }
        }

        public void SetActionTargetLocation(Vector3 location) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].SetActionTargetLocation(location);
            }
        }

        public void SetSelectedEntities(Entity[] entities) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].UnsetSelected();
            }
            selectedEntities.Clear();
            AddSelectedEntities(entities);
        }
    }
}