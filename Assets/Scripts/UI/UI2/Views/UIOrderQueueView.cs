using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Orders;
using RTS.Entities;
using UnityEngine.UI;

namespace RTS.UI.Views {
    public class UIOrderQueueView : MonoBehaviour
    {
        public Text placeholder;
        public void SetOrderQueue(Queue<Order> orderQueue)
        {
            if (orderQueue == null) placeholder.text = "";
            else {
                string output = null;
                int orderQueueLength = orderQueue.Count;

                Queue<Order>.Enumerator enumerator = orderQueue.GetEnumerator();
                while(enumerator.MoveNext()) {
                    Debug.Log(enumerator.Current.ToString());
                    if (output == null)
                    {
                        output = "";
                    } else
                    {
                        output += ", ";
                    }
                    output += enumerator.Current.orderType.ToString();
                }

                placeholder.text = output;
            }
        }
    }
}
