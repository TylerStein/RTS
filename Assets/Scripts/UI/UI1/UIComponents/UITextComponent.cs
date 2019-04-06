using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class UITextComponent : UIComponent {
	public string numberFormat = "N2";
	private Text text;

	public UITextComponent() : base() {	}

	void Start() {
		text = GetComponent<Text>();
		rectTransform = GetComponent<RectTransform>();
	}

	public override void SetValue(string value) {
		text.text = value;
	}

	public override void SetValue(float value) {
		text.text = value.ToString(numberFormat);
	}

	public override void SetValue(int value) {
		text.text = value.ToString(numberFormat);
	}

	public override void SetValue(object value) {
		text.text = "[object]";
	}
}
