using UnityEngine.UI;
using UnityEngine;

public class Tooltip : MonoBehaviour
{
    public Text text;

    private RectTransform _rectTransform;
    public void Awake() {
        _rectTransform = GetComponent<RectTransform>();
        if (!text) text = GetComponent<Text>();
    }

    public void SetRectPosition(Vector3 position) {
        _rectTransform.position = position;
    }

    public void SetContent(string content) {
        text.text = content;
    }
    
}
