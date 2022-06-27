using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(EventTrigger))]
public class UI_Inventory_Footer_ExpandAnchor : MonoBehaviour
{
    private Action<float> draggingAction = null;

    private EventTrigger anchorEventTrigger;
    private RectTransform expandAnchorRectTransform;

    private float dragStartingPoint;

    private void Awake()
    {
        expandAnchorRectTransform = GetComponent<RectTransform>();
        anchorEventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry onDragEntry = new EventTrigger.Entry();
        onDragEntry.eventID = EventTriggerType.Drag;
        onDragEntry.callback.AddListener(OnDrag);
        anchorEventTrigger.triggers.Add(onDragEntry);
    }

    public void Setup(float height, float margin, Action<float> draggingAction)
    {
        this.draggingAction = draggingAction;

        Vector2 buttonSizeDelta;
        buttonSizeDelta.x = height - margin * 2;
        buttonSizeDelta.y = height - margin * 2;

        expandAnchorRectTransform.sizeDelta = buttonSizeDelta;
        expandAnchorRectTransform.anchoredPosition = Vector2.left * margin;
    }

    private void OnDrag(BaseEventData data)
    {
        if (data is PointerEventData pointerData)
        {
            draggingAction?.Invoke(pointerData.position.x - expandAnchorRectTransform.position.x);
        }
    }
}