using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using RTS.Orders;

[RequireComponent(typeof(Text))]
public class OrderButtonCard : ButtonCard
{
    public Text text;


    public OrderButtonCard() : base()
    {

    }

    void Awake() {
        Debug.Log("OrderButtonCard Awake");
        this.text = GetComponent<Text>();
    }

    public override void OnSet() {
        if (value != null) {
            OrderType orderType;
            try {
                orderType = (OrderType)value;
                text.text = orderType.ToString();
                text.color = Color.white;
            } catch (System.Exception e) {
                Debug.LogError(e);
                text.text = "ERROR";
                text.color = Color.red;
            }
        }
    }
}
