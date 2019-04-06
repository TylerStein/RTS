using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UIView : MonoBehaviour {
	public TooltipController tooltipController;
	public Player owner;
	public UIController controller;
	public List<UIComponent> components = new List<UIComponent>();
	public Dictionary<string, int> componentKeyIndex = new Dictionary<string, int>();

	void Start() {
		// controller = owner.UIController;
		for (int i = 0; i < components.Count; i++) {
			int componentIndex = i;
			string key = components[i].Key;
			components[i].view = this;
			switch (components[i].Type) {
				case EValueType._int: 
					controller.AddListener(key, (int value) => {
						UpdateDisplay(value, componentIndex);
					});
					if (components[i].GetInitialValue) {
						int val;
						controller.TryGetValue(key, out val);
						UpdateDisplay(val, i);
					}		
					break;
				case EValueType._float:
					controller.AddListener(key, (float value) => {
						UpdateDisplay(value, componentIndex);
					});
					if (components[i].GetInitialValue) {
						float val;
						controller.TryGetValue(key, out val);
						UpdateDisplay(val, i);
					}					
					break;
				case EValueType._string:
					controller.AddListener(key, (string value) => {
						UpdateDisplay(value, componentIndex);
					});
					if (components[i].GetInitialValue) {
						string val;
						controller.TryGetValue(key, out val);
						if (val != null) UpdateDisplay(val, i);
					}
					break;
				case EValueType._object:
					controller.AddListener(key, (object value) => {
						UpdateDisplay(value, componentIndex);
					});
					if (components[i].GetInitialValue) {
						object val;
						controller.TryGetValue(key, out val);
						if (val != null) UpdateDisplay(val, i);
					}
				break;
				default: break;
			}

		}
	}

	void UpdateDisplay(string value, int componentIndex) {
		components[componentIndex].SetValue(value);
	}

	void UpdateDisplay(int value, int componentIndex) {
		components[componentIndex].SetValue(value);
	}

	void UpdateDisplay(float value, int componentIndex) {
		components[componentIndex].SetValue(value);
	}

	void UpdateDisplay(object value, int componentIndex) {
		components[componentIndex].SetValue(value);
	}
}
