using UnityEngine.UI;
using UnityEngine;

namespace RTS.UI.Views {
    public class UIContextInfoView : MonoBehaviour
    {
        public Sprite defaultSprite;

        public Text nameText;
        public Image spriteImage;

        public void Start()
        {
            ClearDisplaySprite();
            ClearDisplayName();
        }

        public void SetDisplayName(string displayName)
        {
            nameText.text = displayName;
        }

        public void ClearDisplayName()
        {
            nameText.text = "";
        }

        public void SetDisplaySprite(Sprite displaySprite)
        {
            spriteImage.sprite = displaySprite;
        }

        public void ClearDisplaySprite()
        {
            spriteImage.sprite = defaultSprite;
        }
    }
}