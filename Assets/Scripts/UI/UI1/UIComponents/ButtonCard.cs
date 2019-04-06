using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public abstract class ButtonCard : MonoBehaviour, IPointerClickHandler
{
    protected UnityAction callback;
    protected object value;

    public ButtonCard() {

    }

    public object Value
    {
        get
        {
            return value;
        }

        set
        {
            this.value = value;
            OnSet();
        }
    }

    public abstract void OnSet();

    public void SetCallback(UnityAction action) {
        this.callback = action;
    }

    public void ClearCallback() {
        callback = null;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (callback != null) callback.Invoke();
    }
}
