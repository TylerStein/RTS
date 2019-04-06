using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using RTS.Entities;

public class UICardListComponent : UIComponent {
	public ScrollViewHandler scrollViewHandler;

	public void Start() {
		rectTransform = GetComponent<RectTransform>();
	}

	public UICardListComponent() : base() {
	}

    public override void SetValue(string value) { 
		//
	}

	public override void SetValue(float vlaue) { 
		//
	}

	public override void SetValue(int value) { 
		//
	}

	public override void SetValue(object value) { 
		Debug.Log("UICardListComponent.SetValue " + value);
		try {
			Unit[] inUnits = (Unit[])value;
			scrollViewHandler.RemoveAllCards();
			for (int i = 0; i < inUnits.Length; i++) {
				ScrollCard card = new ScrollCard();
				card.id = inUnits[i].GetInstanceID();
				card.card = inUnits[i].gameObject;
				card.context = inUnits[i].entity;
				scrollViewHandler.AddCard(card, (ScrollCard c) => {
					Debug.Log("Clicked " + c.context.displayName);
				});
			}
		} catch (System.Exception e) {
			Debug.LogError(e);
		}
	}
}
