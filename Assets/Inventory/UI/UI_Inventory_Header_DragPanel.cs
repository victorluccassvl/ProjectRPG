using System;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent(typeof(RectTransform))]
[RequireComponent(typeof(EventTrigger))]
public class UI_Inventory_Header_DragPanel : MonoBehaviour
{
    [SerializeField] private RectTransform dragPanelRectTransform;
    [SerializeField] private EventTrigger panelEventTrigger;
    private Action<Vector2> draggingAction = null;

    private void Awake()
    {
        EventTrigger.Entry onDrag = new EventTrigger.Entry();
        onDrag.eventID = EventTriggerType.Drag;
        onDrag.callback.AddListener(OnDrag);
        panelEventTrigger.triggers.Add(onDrag);
    }

    public void Setup(float width, float height, Action<Vector2> draggingAction)
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
            draggingAction?.Invoke(pointerData.delta);
        }
    }
}