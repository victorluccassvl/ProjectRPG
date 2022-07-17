using UnityEngine;

public class InventorySlotSO : ScriptableObject
{
    [SerializeField] private InventoryItemSO item;

    public InventoryItemSO Item
    {
        get
        {
            return item;
        }
        private set
        {
            Clear();
            item = value;
        }
    }

    public void Clear()
    {
        this.item = null;
    }

    public void SetItem(InventoryItemSO item)
    {
        Item = item;
    }
}
