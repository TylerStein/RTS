using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class UITooltip : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public UIView view;
    public RectTransform rectTransform;
    public TooltipContent tooltipContent;

    public void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        view.tooltipController.OnEnterComponent(this, tooltipContent);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        view.tooltipController.OnExitComponent(this);
    }
}
