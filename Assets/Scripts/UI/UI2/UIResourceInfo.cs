using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;
using RTS.UI.Views;

namespace RTS.UI
{
    public class UIResourceInfo : MonoBehaviour
    {
        public UIResourceInfoView resourceInfoView;

        public void SetResourceValue(ResourceType resourceType, int value)
        {
            switch (resourceType)
            {
                case ResourceType.wood:
                    resourceInfoView.SetWoodResourceValue(value);
                    return;
                case ResourceType.stone:
                    resourceInfoView.SetStoneResourceValue(value);
                    return;
                default: throw new UnityException("Invalid Resource Type");
            }
        }
    }
}