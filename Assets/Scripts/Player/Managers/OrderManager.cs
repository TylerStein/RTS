using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using RTS.Orders;

public class OrderManager : PlayerManager
{
    public UnityEvent orderChangeListener;

    private OrderDefinition selectedOrder;
    public OrderDefinition SelectedOrder {
        get {
            return selectedOrder;
        }
        set {
            selectedOrder = value;
            OnChangeSelectedOrder();
        }
    }

    public OrderManager(Player _player) : base(_player) {
        
    }

    public override void PostInitialize()
    {
        
    }

    public void SetOrderChangeListener(UnityEvent callback) {
        orderChangeListener = callback;
    }

    public void RemoveOrderChangeListener() {
        orderChangeListener = null;
    }

    private void OnChangeSelectedOrder() {
        if (orderChangeListener != null) orderChangeListener.Invoke();
    }
}