using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(RectTransform))]
public class UI_Inventory_SlotGrid : MonoBehaviour
{
    [SerializeField] private GameObject slotTemplate;

    private int columns;
    private int lines;

    private GridLayoutGroup slotGridLayout;
    private RectTransform slotGroupTransform;
    private List<GameObject> currentSlots;

    private void Awake()
    {
        slotGridLayout = GetComponent<GridLayoutGroup>();
        slotGroupTransform = GetComponent<RectTransform>();
    }

    public void Setup(Vector2 position, float size, float spacing, int lines, int columns, InventorySO inventoryData)
    {
        slotGroupTransform.anchoredPosition = position;

        slotGridLayout.cellSize = size * Vector2.one;
        slotGridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        slotGridLayout.constraintCount = columns;
        slotGridLayout.spacing = spacing * Vector3.one;

        this.columns = columns;
        this.lines = lines;

        Vector2 slotGroupTransformSize;
        slotGroupTransformSize.x = size * columns + spacing * (columns + 1);
        slotGroupTransformSize.y = size * lines + spacing * (lines + 1);

        slotGroupTransform.sizeDelta = slotGroupTransformSize;
    }
}
