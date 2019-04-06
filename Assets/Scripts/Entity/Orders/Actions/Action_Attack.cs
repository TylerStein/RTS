using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.Orders {
    public class Action_Attack : OrderAction
    {
        public Entity attackTarget;

        public Action_Attack(Order _order) : base(_order)
        {
        }

        public override string GetDesctiptor() {
            return string.Format("Order (type={0}, attackTarget={1})", order.orderType.ToString(), attackTarget.ToString());
        }
    }
}