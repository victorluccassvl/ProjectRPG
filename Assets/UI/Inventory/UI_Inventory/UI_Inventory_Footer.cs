using UnityEngine;
using TMPro;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class UI_Inventory_Footer : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private TextMeshProUGUI footerText;
    [SerializeField] private RectTransform closeButton;

    [HideInInspector] public RectTransform footerTransform;

    private void Awake()
    {
        footerTransform = GetComponent<RectTransform>();
    }

    public void Setup(float width)
    {
        Vector2 footerTransformSize;
        footerTransformSize.x = width;
        footerTransformSize.y = height;

        footerTransform.sizeDelta = footerTransformSize;
    }
}
