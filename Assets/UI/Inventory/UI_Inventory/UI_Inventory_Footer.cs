using System;
using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UI_Inventory_Footer : MonoBehaviour
{
    [SerializeField] private RectTransform expandButton;

    private RectTransform footerRectTransform;

    private void Awake()
    {
        footerRectTransform = GetComponent<RectTransform>();
    }

    public void Setup(Vector2 position, float width, float height, float anchorMargin)
    {
        footerRectTransform.anchoredPosition = position;

        Vector2 footerTransformSize;
        footerTransformSize.x = width;
        footerTransformSize.y = height;

        footerRectTransform.sizeDelta = footerTransformSize;
    }
}
