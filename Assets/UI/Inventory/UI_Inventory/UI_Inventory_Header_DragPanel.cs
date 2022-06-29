using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(EventTrigger))]
public class UI_Inventory_Header_DragPanel : MonoBehaviour
{
    private Action<Vector2, Vector2> draggingAction = null;

    private EventTrigger panelEventTrigger;
    private RectTransform dragPanelRectTransform;

    private void Awake()
    {
        dragPanelRectTransform = GetComponent<RectTransform>();
        panelEventTrigger = GetComponent<EventTrigger>();

        EventTrigger.Entry onDrag = new EventTrigger.Entry();
        onDrag.eventID = EventTriggerType.Drag;
        onDrag.callback.AddListener(OnDrag);
        panelEventTrigger.triggers.Add(onDrag);
    }

    public void Setup(float width, float height, Action<Vector2, Vector2> draggingAction)
    {
        this.draggingAction = draggingAction;

        Vector2 buttonSizeDelta;
        buttonSizeDelta.x = width;
        buttonSizeDelta.y = height;

        dragPanelRectTransform.sizeDelta = buttonSizeDelta;
        dragPanelRectTransform.anchoredPosition = Vector2.zero;
    }

    private void OnDrag(BaseEventData data)
    {
        if (data is PointerEventData pointerData)
        {
            draggingAction?.Invoke(pointerData.position, pointerData.pressPosition);
        }
    }
}