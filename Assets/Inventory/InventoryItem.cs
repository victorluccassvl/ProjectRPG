using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryItem
{
    [SerializeField] private int itemID = -1;

    public int GetItemID()
    {
        return itemID;
    }
}
