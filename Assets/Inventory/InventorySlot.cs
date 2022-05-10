using UnityEngine;

public class InventorySlot : MonoBehaviour
{
    [SerializeField] private InventoryItem item;
    public int nextSlotIndex = -1;

    public void Clear()
    {
        this.item = null;
    }

    public void SetItem(InventoryItem item)
    {
        this.Clear();
        this.item = item;
    }
}
