using UnityEngine;

[RequireComponent(typeof(RectTransform))]
public class UI_Inventory_Footer : MonoBehaviour
{
    [SerializeField] private RectTransform expandButton;

    private RectTransform footerTransform;

    private void Awake()
    {
        footerTransform = GetComponent<RectTransform>();
    }

    public void Setup(Vector2 position, float height, float width)
    {
        footerTransform = GetComponent<RectTransform>();
        footerTransform.anchoredPosition = position;

        Vector2 footerTransformSize;
        footerTransformSize.x = width;
        footerTransformSize.y = height;

        footerTransform.sizeDelta = footerTransformSize;
    }
}
