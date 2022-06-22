using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(RectTransform))]
public class UI_Inventory_SlotGrid : MonoBehaviour
{
    private int slotsCurrentColumns;
    private int slotsCurrentLines;

    private GridLayoutGroup slotGridLayout;
    private RectTransform slotGroupTransform;

    private void Awake()
    {
        slotGridLayout = GetComponent<GridLayoutGroup>();
        slotGroupTransform = GetComponent<RectTransform>();
    }

    public void Setup(Vector3 position, float size, float spacing, int startingColumns, int startingLines, InventorySO inventoryData)
    {
        slotGroupTransform.anchoredPosition = position;

        slotGridLayout.cellSize = size * Vector2.one;
        slotGridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        slotGridLayout.constraintCount = startingColumns;
        slotGridLayout.spacing = size * Vector3.one;

        slotsCurrentColumns = startingColumns;
        slotsCurrentLines = startingLines;

        Vector2 slotGroupTransformSize;
        slotGroupTransformSize.x = size * slotsCurrentColumns + spacing * (slotsCurrentColumns + 1);
        slotGroupTransformSize.y = size * slotsCurrentLines + spacing * (slotsCurrentLines + 1);

        slotGroupTransform.sizeDelta = slotGroupTransformSize;
    }
}
