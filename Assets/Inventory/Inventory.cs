using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int capacity = 10;
    [SerializeField] private InventorySlot inventorySlotPrefab;

    private List<InventorySlot> slotsPool = null;
    private List<InventorySlot> inventory = null;

    private void Awake()
    {
        this.capacity = Mathf.Max(1, this.capacity);
        this.slotsPool = new List<InventorySlot>(this.capacity);
        this.inventory = new List<InventorySlot>(this.capacity);

        for (int i = 0; i < capacity; i++)
        {
            InventorySlot inventorySlot = Instantiate<InventorySlot>(inventorySlotPrefab, this.transform);
            inventorySlot.enabled = false;
            slotsPool.Add(inventorySlot);
        }
    }

    public bool AddItemToInventoryEnd(InventoryItem item)
    {
        if (item == null) return false;
        if (slotsPool.Count == 0) return false;

        InventorySlot availableSlot = slotsPool[0];
        availableSlot.SetItem(item);

        slotsPool.Remove(availableSlot);
        inventory.Add(availableSlot);

        return true;
    }

    public bool AddItemToInventoryIndex(InventoryItem item, int index)
    {
        if (item == null) return false;
        if (slotsPool.Count == 0) return false;

        InventorySlot availableSlot = slotsPool[0];
        availableSlot.SetItem(item);

        slotsPool.Remove(availableSlot);
        inventory.Insert(index, availableSlot);

        return true;
    }

    public bool RemoveItemFromInventory(InventoryItem item)
    {
        if (item == null) return false;

        InventorySlot slotToClear = inventory.Find(inventorySlot => inventorySlot.Item == item);

        if (slotToClear == null) return false;

        inventory.Remove(slotToClear);
        slotToClear.Clear();
        slotsPool.Add(slotToClear);

        return true;
    }

    public bool RemoveItemFromInventorySlot(InventorySlot slot)
    {
        if (slot == null) return false;
        if (!inventory.Contains(slot)) return false;

        inventory.Remove(slot);
        slot.Clear();
        slotsPool.Add(slot);

        return true;
    }

    public bool UpdateInventoryCapacity(int newCapacity)
    {
        int usedSlots = capacity - slotsPool.Count;

        if (newCapacity < 1) return false;
        if ((newCapacity < capacity) && (capacity - slotsPool.Count > newCapacity)) return false;

        List<InventorySlot> newInventory = new List<InventorySlot>(newCapacity);
        List<InventorySlot> newPool = new List<InventorySlot>(newCapacity);
        this.capacity = newCapacity;

        foreach (InventorySlot slot in inventory)
        {
            newInventory.Add(slot);
        }
        inventory = newInventory;

        int requiredSlots = newCapacity - usedSlots;

        foreach (InventorySlot slot in slotsPool)
        {
            if (requiredSlots > 0)
            {
                newPool.Add(slot);
                requiredSlots--;
            }
            else
            {
                Destroy(slot.gameObject);
            }
        }

        for (int i = 0; i < requiredSlots; i++)
        {
            InventorySlot inventorySlot = Instantiate<InventorySlot>(inventorySlotPrefab, this.transform);
            inventorySlot.enabled = false;
            newPool.Add(inventorySlot);
        }

        slotsPool = newPool;

        return true;
    }

    public bool SwapItemsBetweenSlots(InventoryItem itemA, InventoryItem itemB)
    {
        if (itemA == null || itemB == null) return false;

        InventorySlot slotA = inventory.Find(inventorySlot => inventorySlot.Item == itemA);
        InventorySlot slotB = inventory.Find(inventorySlot => inventorySlot.Item == itemB);

        if (slotA == null || slotB == null) return false;

        slotB.SetItem(itemA);
        slotA.SetItem(itemB);

        return true;
    }
}
