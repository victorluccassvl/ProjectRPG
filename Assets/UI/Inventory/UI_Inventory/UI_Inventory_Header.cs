using UnityEngine;
using TMPro;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class UI_Inventory_Header : MonoBehaviour
{
    [SerializeField] private float height;
    [SerializeField] private TextMeshProUGUI headerText;
    [SerializeField] private RectTransform closeButton;

    [HideInInspector] public RectTransform headerTransform;

    private void Awake()
    {
        headerTransform = GetComponent<RectTransform>();
    }

    public void Setup(float width)
    {
        Vector2 headerTransformSize;
        headerTransformSize.x = width;
        headerTransformSize.y = height;

        headerTransform.sizeDelta = headerTransformSize;
    }
}
