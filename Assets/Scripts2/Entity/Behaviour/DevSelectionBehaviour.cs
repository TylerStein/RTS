using UnityEngine;

namespace RTS2.Entities.Behaviours {
    public class DevSelectionBehaviour : EntityBehaviour
    {
        Renderer entityRenderer;
        public DevSelectionBehaviour() : base() {
            //
        }

        private void Awake() {
            entityRenderer = entity.gameObject.GetComponent<Renderer>();
        }

        public override void OnPrimarySelect() {
            entityRenderer.material.color = Color.green;
        }

        public override void OnPrimaryUnselect() {
            entityRenderer.material.color = Color.white;
        }
    }
}