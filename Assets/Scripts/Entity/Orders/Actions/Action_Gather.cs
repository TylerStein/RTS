using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.Orders {
    public class Action_Gather : OrderAction
    {
        public Entity target;
        public int extractionRate = 2;

        public Action_Gather(Entity _target, Order _order) : base(_order) {
            target = _target;
        }
        
        public override string GetDesctiptor() {
            return string.Format("Order (type={0}, target={1})", order.orderType.ToString(), target.resource.ToString());
        }

        public override void Execute() {
            isComplete = false;
            isExecuted = true;
        }

        public override void Update() {
            if (isComplete == false) {
                if (target.resource.resourceContent > 0) {
                    int extracted = target.resource.TakeResources(extractionRate);
                    target.owner.ResourceManager.AddResource(extracted, target.resource.resourceType);
                } else {
                    isComplete = true;
                }
            }
        }

        public override void Cancel() {
            isComplete = true;
            isExecuted = false;
        }
    }
}