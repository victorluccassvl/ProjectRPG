using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Inventory : UI_Element
{
    [SerializeField] private Image slotPrefab;
    private List<Image> slotImage;

    public void Setup(InventorySO inventoryData)
    {
        for (int i = 0; i < inventoryData.Capacity; i++)
        {
            Image image = Instantiate<Image>(slotPrefab, this.transform);
            slotImage.Insert(i, image);
        }
    }
}
