using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform))]
[ExecuteInEditMode]
public class UI_Inventory : UI_Element
{
    [SerializeField] private UI_Inventory_Header header;
    [SerializeField] private UI_Inventory_SlotGrid slotGrid;
    [SerializeField] private UI_Inventory_Footer footer;


    [Header("Background")]
    [SerializeField] RectTransform backgroundTransform;
    [SerializeField] private float backgroundMargin;

    [Header("Main Layout")]
    [SerializeField] RectTransform mainLayoutTransform;

    [SerializeField] private Image slotPrefab;
    private List<Image> slotImage;

    protected override void OnEnable()
    {
        base.OnEnable();
        Setup(null);
    }

    public void SetupInventoryData(InventorySO inventoryData)
    {
        for (int i = 0; i < inventoryData.Capacity; i++)
        {
            Image image = Instantiate<Image>(slotPrefab, this.transform);
            slotImage.Insert(i, image);
        }
    }

    public void Setup(InventorySO inventoryData)
    {
        slotGrid.Setup(inventoryData);
        header.Setup(slotGrid.slotGroupTransform.sizeDelta.x);
        footer.Setup(slotGrid.slotGroupTransform.sizeDelta.x);

        header.headerTransform.anchoredPosition = Vector2.zero;
        slotGrid.slotGroupTransform.anchoredPosition = header.headerTransform.anchoredPosition + Vector2.down * header.headerTransform.sizeDelta.y;
        footer.footerTransform.anchoredPosition = slotGrid.slotGroupTransform.anchoredPosition + Vector2.down * slotGrid.slotGroupTransform.sizeDelta.y;
    }
}
