using UnityEngine;
using System.Collections.Generic;
using RTS2.Entity;

namespace RTS2.Player
{
    public class BasicEntitySelectionHandler : MonoBehaviour, IEntitySelectionHandler
    {
        private List<IEntity> selectedEntities;

        public IEntity GetSelectedEntity(int index = 0) {
            if (selectedEntities.Count >= index) throw new UnityException("EntityIndexOutOfBouns: There is no entity at index " + index + "!");
            else return selectedEntities[index];
        }

        public List<IEntity> GetSelectedEntities() {
            return selectedEntities;
        }

        public void AddActionTargetEntities(IEntity[] entities) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].AddActionTargetEntities(entities);
            }
        }

        public void AddActionTargetLocation(Vector3 location) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].AddActionTargetLocation(location);
            }
        }

        public void AddSelectedEntities(IEntity[] entities) {
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

        public void SetActionTargetEntities(IEntity[] entities) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].SetActionTargetEntities(entities);
            }
        }

        public void SetActionTargetLocation(Vector3 location) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].SetActionTargetLocation(location);
            }
        }

        public void SetSelectedEntities(IEntity[] entities) {
            for (int i = 0; i < selectedEntities.Count; i++) {
                selectedEntities[i].UnsetSelected();
            }
            selectedEntities.Clear();
            AddSelectedEntities(entities);
        }
    }
}