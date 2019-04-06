using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS.Orders;

public class UIGridListComponent : UIComponent
{
    public float maxItems = 12;

    public List<ButtonCard> cards = new List<ButtonCard>();

    private List<object> content;
    private GridLayoutGroup gridLayoutGroup;

    public UIGridListComponent() : base() {
        //
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
		Debug.Log("UIGridListComponent.SetValue " + value);
        if (value == null) {
             ClearItems();
             return;
        }
        try {
            OrderType[] inOrders = (OrderType[])value;
            ClearItems();
            for (int i = 0; i < inOrders.Length; i++) {
                AddItem(inOrders[i]);
            }
         } catch (System.Exception e) {
            Debug.LogError(e);
         }
    }

    // Start is called before the first frame update
    void Start()
    {
        content = new List<object>();
        gridLayoutGroup = GetComponent<GridLayoutGroup>();
        Refresh();
    }

    void AddItem(object item) {
        if (content.Count < maxItems) content.Add(item);
        Debug.Log("AddItem " + item);
        Refresh();
    }

    void RemoveItem(object item) {
        int idx = content.FindIndex((object o) => o == item);
        if (idx >= 0) {
            content.RemoveAt(idx);
        }
        Refresh();
    }

    void ClearItems() {
        content.Clear();
        Refresh();
    }

    void Refresh() {
        Debug.Log("Refreshing UIGridList");
        for (int i = 0; i < cards.Count; i++) {
            if (i < content.Count) {
                cards[i].gameObject.SetActive(true);
                cards[i].enabled = true;
                cards[i].Value = (content[i]);
            } else {
                cards[i].gameObject.SetActive(false);
                cards[i].Value = null;
            }
        }
    }
}
