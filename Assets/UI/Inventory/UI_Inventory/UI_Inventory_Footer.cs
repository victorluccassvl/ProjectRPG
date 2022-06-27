using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UI_Inventory_Footer : MonoBehaviour
{
    [SerializeField] private RectTransform expandButton;
    [SerializeField] private UI_Inventory_Footer_ExpandAnchor expandAnchor;

    private RectTransform footerTransform;

    private void Awake()
    {
        footerTransform = GetComponent<RectTransform>();
    }

    public void Setup(Vector2 position, float height, float width, float anchorMargin, Action<float> draggingAction)
    {
        footerTransform = GetComponent<RectTransform>();
        footerTransform.anchoredPosition = position;

        Vector2 footerTransformSize;
        footerTransformSize.x = width;
        footerTransformSize.y = height;

        footerTransform.sizeDelta = footerTransformSize;

        expandAnchor.Setup(height, anchorMargin, draggingAction);
    }
}
