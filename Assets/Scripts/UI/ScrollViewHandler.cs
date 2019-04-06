using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using RTS.Entities;

[System.Serializable]
public struct ScrollCard {
	public int id;
	public Sprite sprite;
	public GameObject card;
	public Entity context;
}

[System.Serializable]
public class CardClickedEvent : UnityEvent<ScrollCard> { 
	//
}

public class ScrollViewHandler : MonoBehaviour {
	public List<ScrollCard> cards = new List<ScrollCard>();

	public Sprite testSprite;
	public GameObject cardPrefab;
	public float leftCardSpacing;

	List<RectTransform> content = new List<RectTransform>();
	RectTransform tr;

	void Start() {
		tr = GetComponent<RectTransform>();
	}

	public ScrollCard AddCard(ScrollCard card, UnityAction<ScrollCard> onClickAction) {
		GameObject newItem = Instantiate(cardPrefab) as GameObject;
		
		if (newItem != null) {
			card.card = newItem;
			if (!card.sprite) card.sprite = testSprite;

			newItem.GetComponent<Image>().sprite = card.sprite;
			newItem.GetComponent<Button>().onClick.AddListener(() => { onClickAction(card); });

			Debug.Log("Created card object ", newItem);

			RectTransform rt = newItem.GetComponent<RectTransform>();
			content.Add(rt);
			cards.Add(card);

			Debug.Log("Setting card parent to ", tr);
			rt.SetParent(tr, false);

			// UpdateItemOffsets();
		}

		return card;
	}

	public void RemoveAllCards() {
		for (int i = cards.Count - 1; i > 0; i++) {
			RemoveCard(cards[i]);
		}
	}

	public void RemoveCard(ScrollCard card) {
		if (this.cards.Contains(card)) {
			card.card.GetComponent<Button>().onClick.RemoveAllListeners();
			content.Remove(card.card.GetComponent<RectTransform>());
			cards.Remove(card);
			Destroy(card.card);
		}
	}

	void UpdateItemOffsets() {
		// float xOffset = leftCardSpacing;
		// for (int i = 0; i < content.Count; i++) {
		// 	Rect cardRect = content[i].rect;
		// 	content[i].rect.Set(xOffset, 0, 150, 150);
		// 	xOffset += content[i].rect.width + leftCardSpacing;
		// }
	}
}
