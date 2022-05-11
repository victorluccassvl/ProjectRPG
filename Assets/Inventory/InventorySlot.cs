using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    private InventoryItem item;

    public InventoryItem Item
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

    public void SetItem(InventoryItem item)
    {
        Item = item;
    }
}
