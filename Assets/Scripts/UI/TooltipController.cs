using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TooltipContent {
    public TooltipContent(string msg) { message = msg; }
    public string message;
}

public class TooltipController : MonoBehaviour
{
    // The time it takes for tooltip to appear
    public float tooltipEnterTime = 0.6f;

    // The tooltip gameObject
    public GameObject tooltipObject;

    // Mouse position handler
    public MousePosition mousePosition;

    private Tooltip _tooltip;

    private UITooltip _pendingTooltip;
    private TooltipContent _pendingContent;

    private bool _isPending = false;

    private float _currentTime = 0f;

    public void Start() {
        _tooltip = tooltipObject.GetComponent<Tooltip>();
        tooltipObject.SetActive(false);
    }

    public void OnEnterComponent(UITooltip component, TooltipContent content) {
        if (_pendingTooltip != null) {
            HideTooltip();
        }

        if (component != _pendingTooltip) {
            _isPending = true;
            _pendingTooltip = component;
            _pendingContent = content;
            _currentTime = 0f;
        }
    }

    public void OnExitComponent(UITooltip component) {
        if (component == _pendingTooltip) {
            HideTooltip();
        }
    }

    public void HideTooltip() {
        _tooltip.SetContent("");
        tooltipObject.SetActive(false);
        _pendingTooltip = null;
        _pendingContent = null;
        _isPending = false;
        _currentTime = 0;
    }

    public void DisplayTooltip(UITooltip component, TooltipContent content, Vector3 position) {
        if (!tooltipObject.activeSelf) tooltipObject.SetActive(true);
        _isPending = false;
        _tooltip.SetRectPosition(position);
        _tooltip.SetContent(content.message);
    }

    public void Update() {
        if (_pendingTooltip != null && _isPending == true) {
            if (_currentTime >= tooltipEnterTime) {
                DisplayTooltip(_pendingTooltip, _pendingContent, mousePosition.lastScreenMousePosition);
            } else _currentTime += Time.deltaTime;
        }
    }
}
