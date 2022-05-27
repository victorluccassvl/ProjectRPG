using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(GridLayoutGroup))]
[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class UI_Inventory_SlotGrid : MonoBehaviour
{
    [SerializeField] private float slotSize;
    [SerializeField] private int slotsCurrentColumns;
    [SerializeField] private int slotCurrentLines;
    [SerializeField] private float slotSpacing;

    private GridLayoutGroup slotGridLayout;

    [HideInInspector] public RectTransform slotGroupTransform;

    private void Awake()
    {
        slotGridLayout = GetComponent<GridLayoutGroup>();
        slotGroupTransform = GetComponent<RectTransform>();
    }

    public void Setup(InventorySO inventoryData)
    {
        slotGridLayout.cellSize = slotSize * Vector2.one;
        slotGridLayout.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        slotGridLayout.constraintCount = slotsCurrentColumns;
        slotGridLayout.spacing = slotSpacing * Vector3.one;

        Vector2 slotGroupTransformSize;
        slotGroupTransformSize.x = slotSize * slotsCurrentColumns + slotSpacing * (slotsCurrentColumns + 1);
        slotGroupTransformSize.y = slotSize * slotCurrentLines + slotSpacing * (slotCurrentLines + 1);

        slotGroupTransform.sizeDelta = slotGroupTransformSize;
    }
}
