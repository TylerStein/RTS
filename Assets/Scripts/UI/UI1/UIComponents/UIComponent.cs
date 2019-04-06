using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class UIComponent : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler {
	public bool GetInitialValue = false;
	public UIView view;
	public string Key = "";
	public EValueType Type = EValueType._string;
	public RectTransform rectTransform;

	public UIComponent() {}
    public abstract void SetValue(string value);
	public abstract void SetValue(float vlaue);
	public abstract void SetValue(int value);
	public abstract void SetValue(object value);

    public void OnPointerEnter(PointerEventData eventData) {
	}

    public void OnPointerClick(PointerEventData eventData) {
		//
	}

    public void OnPointerExit(PointerEventData eventData) {
	}
}
