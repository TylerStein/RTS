using UnityEngine;

namespace RTS2.Entities.Behaviours {
    [CreateAssetMenu(fileName = "New Selection Behaviour", menuName = "RTS2/Behaviours/Selection Behaviours")]
    public class EntitySelectionBehaviour : ScriptableObject
    {
        [SerializeField] Color selectedColor = Color.green;
        [SerializeField] Color defaultColor = Color.white;

        public void OnPrimarySelect(Renderer renderer) {
            renderer.material.color = selectedColor;
        }

        public void OnPrimaryUnselect(Renderer renderer) {
            renderer.material.color = defaultColor;
        }
    }
}