using UnityEngine;
using UnityEngine.UI;

using RTS2.Input;
namespace RTS2.UI
{
    class InputVisualizer : MonoBehaviour
    {
        public RectTransform selectTransform = null;
        public Image selectImage = null;
        public Camera mainCamera = null;
        public Canvas canvas = null;

        private Vector2 selectStart = Vector2.zero;

        private bool lastPrimary = false;
        private bool primary = false;

        public void Update() {
            primary = UnityEngine.Input.GetButton("Primary");

            Vector3 viewportMouse = mainCamera.ScreenToViewportPoint(UnityEngine.Input.mousePosition);
            // Somehow convert this to canvas space?

            if (primary) {
                if (lastPrimary) {
                    UpdateSelect(viewportMouse);
                } else {
                    lastPrimary = true;
                    BeginSelect(viewportMouse);
                }
            } else if (lastPrimary) {
                EndSelect();
            }

            lastPrimary = primary;
        }

        public void BeginSelect(Vector3 start) {
            selectStart = start;
            selectImage.enabled = true;
            selectTransform.anchoredPosition = new Vector2(start.x, -start.y);
            selectTransform.sizeDelta = Vector2.one * 10;
        }

        public void UpdateSelect(Vector3 pos) {
            Vector2 origin = Vector2.zero;
            Vector2 size = Vector2.one;

            origin = pos * new Vector2(1, -1);
           // size = new Vector2(pos.x, pos.y) - origin;

            //if (pos.x < selectStart.x) {
            //    origin.x = pos.x;
            //    size.x = selectStart.x - pos.x;
            //} else {
            //    origin.x = selectStart.x;
            //    size.x = pos.x - selectStart.x;
            //}

            //if (pos.y < selectStart.y) {
            //    origin.y = pos.y;
            //    size.y = selectStart.y - pos.y;
            //} else {
            //    origin.y = selectStart.y;
            //    size.y = pos.y - selectStart.y;
            //}

            selectTransform.anchoredPosition = origin;
           // selectTransform.sizeDelta = size;
        }

        public void EndSelect() {
            selectImage.enabled = false;
        }

    }
}
