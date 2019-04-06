using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;
using RTS.UI.Views;

namespace RTS.UI
{
    public class UIContextOrderQueue : MonoBehaviour
    {
        public UIOrderQueueView orderQueueView;

        public void SetContextEntity(Entity ctx)
        {
            orderQueueView.SetOrderQueue(ctx.entityDriver.orders);
        }

        public void UpdateContextEntity(Entity ctx)
        {
            orderQueueView.SetOrderQueue(ctx.entityDriver.orders);
        }

        public void ClearContextEntity()
        {
            orderQueueView.SetOrderQueue(null);
        }
    }
}