using UnityEngine;

public class InventoryItemSO : ScriptableObject
{
    [SerializeField] private int itemID = -1;
    [SerializeField] private bool stackable;
    [SerializeField] private int quantity;
    [SerializeField] private bool usable;
    [SerializeField] private Sprite icon;

    public bool IsUsable()
    {
        return usable;
    }

    public bool IsStackable()
    {
        return stackable;
    }

    public int GetQuantity()
    {
        return quantity;
    }

    public int GetItemID()
    {
        return itemID;
    }

    public Sprite GetIcon()
    {
        return icon;
    }
}
