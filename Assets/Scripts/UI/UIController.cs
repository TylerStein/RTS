using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public enum EValueType {
	_int = 0,
	_float = 1,
	_string = 2,
	_object = 3
}

[System.Serializable]
public class ValueChangedEvent : UnityEvent<string, string> {
	//
}

public class UIController : PlayerManager {
	public UIModel model;

	public ValueChangedEvent OnValueChange = new ValueChangedEvent();

	public Dictionary<string, UnityAction<string>> StringListeners = new Dictionary<string, UnityAction<string>>();
	public Dictionary<string, UnityAction<int>> IntListeners = new Dictionary<string, UnityAction<int>>();
	public Dictionary<string, UnityAction<float>> FloatListeners = new Dictionary<string, UnityAction<float>>();
	public Dictionary<string, UnityAction<object>> ObjectListeners = new Dictionary<string, UnityAction<object>>();

	public UIController(Player _player) : base(_player) {
		model = new UIModel();
	}
	
    public override void PostInitialize()
    {
		//
    }

	public void AddListener(string key, UnityAction<string> callback) {
		StringListeners.Add(key, callback);
	}

	public void AddListener(string key, UnityAction<int> callback) {
		IntListeners.Add(key, callback);
	}

	public void AddListener(string key, UnityAction<float> callback) {
		FloatListeners.Add(key, callback);
	}

	public void AddListener(string key, UnityAction<object> callback) {
		ObjectListeners.Add(key, callback);
	}

    public bool RemoveListener(string key, EValueType _type = EValueType._int) {
		switch (_type) {
			case EValueType._int: return IntListeners.Remove(key);
			case EValueType._float: return FloatListeners.Remove(key);
			case EValueType._string: return StringListeners.Remove(key);
			case EValueType._object: return ObjectListeners.Remove(key);
			default: return false;
		}
	}

	public void SetValue(string key, string value) {
		model.StringValues[key] = value;
		UnityAction<string> action = null;
		StringListeners.TryGetValue(key, out action);
		if (action != null) action.Invoke(value);
	}

	public void SetValue(string key, int value) {
		model.IntValues[key] = value;
		UnityAction<int> action = null;
		IntListeners.TryGetValue(key, out action);
		if (action != null) action.Invoke(value);
	}

	public void SetValue(string key, float value) {
		model.FloatValues[key] = value;
		UnityAction<float> action = null;
		FloatListeners.TryGetValue(key, out action);
		if (action != null) action.Invoke(value);
	}

	public void SetValue(string key, object value) {
		model.ObjectValues[key] = value;
		UnityAction<object> action = null;
		ObjectListeners.TryGetValue(key, out action);
		if (action != null) action.Invoke(value);
	}

	public void TryGetValue(string key, out string value) {
		model.StringValues.TryGetValue(key, out value);
	}

	public void TryGetValue(string key, out int value) {
		model.IntValues.TryGetValue(key, out value);
	}

	public void TryGetValue(string key, out float value) {
		model.FloatValues.TryGetValue(key, out value);
	}

	public void TryGetValue(string key, out object value) {
		model.ObjectValues.TryGetValue(key, out value);
	}
}
