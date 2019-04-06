using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RTS.Entities;
using RTS.UI.Views;

namespace RTS.UI
{
    public class UIContextInfo : MonoBehaviour
    {
        public UIContextInfoView view;

        public void SetContextEntity(Entity ctx)
        {
            view.SetDisplaySprite(ctx.entitySprite);
            view.SetDisplayName(ctx.displayName);
        }

        public void ClearContextEntity()
        {
            view.ClearDisplayName();
            view.ClearDisplaySprite();
        }
    }
}