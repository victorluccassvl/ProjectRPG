using System;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(RectTransform))]
public class UI_Inventory_Header : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private UI_Inventory_Header_CloseButton closeButton;
    [SerializeField] private UI_Inventory_Header_DragPanel dragPanel;

    private RectTransform headerTransform;

    private void Awake()
    {
        headerTransform = GetComponent<RectTransform>();
    }

    public void Setup(Vector2 position, string title, float width, float height, float buttonMargin, Action closeAction, Action<Vector2, Vector2> dragAction)
    {
        headerTransform.anchoredPosition = position;

        Vector2 headerTransformSize;
        headerTransformSize.x = width;
        headerTransformSize.y = height;

        headerTransform.sizeDelta = headerTransformSize;

        headerText.text = title;

        closeButton.Setup(height, buttonMargin, closeAction);
        dragPanel.Setup(width - height - 2 * buttonMargin, height, dragAction);
    }
}
