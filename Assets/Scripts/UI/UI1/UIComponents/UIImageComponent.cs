using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIImageComponent : UIComponent {
    private Image image;

    public UIImageComponent() : base() {}

    void Start() {
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public override void SetValue(string value)
    {
        //
    }

    public override void SetValue(float vlaue)
    {
        //
    }

    public override void SetValue(int value)
    {
        //
    }

    public override void SetValue(object value)
    {
        try {
            Sprite sprite = (Sprite)value;
            image.sprite = sprite;
        } catch (System.Exception e) {
            Debug.LogError(e);
        }
    }
}