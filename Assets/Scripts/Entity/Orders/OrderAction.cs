using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RTS.Orders {
    public class OrderAction
    {
        public Order order;
        public bool isExecuted;
        public bool isComplete;

        public OrderAction(Order _order) {
            order = _order;
        }

        public virtual string GetDesctiptor() {
            return "NULL ORDER ACTION";
        }

        public virtual void Update() {

        }

        public virtual void Execute() {
            isComplete = true;
        }

        public virtual void Cancel() {
            isComplete = false;
            isExecuted = false;
        }
    }
}