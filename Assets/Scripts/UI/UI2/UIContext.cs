using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;

namespace RTS.UI
{
    /** Distributes information among player UI views */
    public class UIContext : MonoBehaviour
    {
        public UIContextInfo contextInfo;
        public UIContextActionCards actionCards;
        public UIContextOrderQueue orderQueue;
        public UIResourceInfo resourcesInfo;

        public Entity context;

        public void SetContextEntity(Entity ctx)
        {
            context = ctx;
            contextInfo.SetContextEntity(context);
            actionCards.SetContextEntity(context);
            orderQueue.SetContextEntity(context);
        }

        public void ClearContextEntity()
        {
            context = null;
            contextInfo.ClearContextEntity();
            actionCards.ClearContextEntity();
            orderQueue.ClearContextEntity();
        }

        public void SetResourceValue(ResourceType resourceType, int value)
        {
            resourcesInfo.SetResourceValue(resourceType, value);
        }

        public void UpdateEntityOrders(Entity entity)
        {
            if (context == entity)
            {
                orderQueue.UpdateContextEntity(entity);
            }
        }
    }
}