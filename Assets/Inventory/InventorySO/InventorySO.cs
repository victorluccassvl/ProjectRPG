using System.Collections.Generic;
using UnityEngine;

public class InventorySO : ScriptableObject
{
    [SerializeField] private int capacity = 10;

    [SerializeField] private List<InventorySlotSO> slotsPool = null;
    [SerializeField] private List<InventorySlotSO> inventory = null;

    public int Capacity
    {
        get => capacity;
    }

    public void Setup(int capacity)
    {
        this.capacity = Mathf.Max(1, capacity);
        this.slotsPool = new List<InventorySlotSO>(this.capacity);
        this.inventory = new List<InventorySlotSO>(this.capacity);

        for (int i = 0; i < capacity; i++)
        {
            InventorySlotSO inventorySlot = CreateInstance<InventorySlotSO>();

            slotsPool.Add(inventorySlot);
        }
    }

    public bool AddItemToInventoryEnd(InventoryItemSO item)
    {
        if (item == null) return false;
        if (slotsPool.Count == 0) return false;

        InventorySlotSO availableSlot = slotsPool[0];
        availableSlot.SetItem(item);

        slotsPool.Remove(availableSlot);
        inventory.Add(availableSlot);

        return true;
    }

    public bool AddItemToInventoryIndex(InventoryItemSO item, int index)
    {
        if (item == null) return false;
        if (slotsPool.Count == 0) return false;

        InventorySlotSO availableSlot = slotsPool[0];
        availableSlot.SetItem(item);

        slotsPool.Remove(availableSlot);
        inventory.Insert(index, availableSlot);

        return true;
    }

    public bool RemoveItemFromInventory(InventoryItemSO item)
    {
        if (item == null) return false;

        InventorySlotSO slotToClear = inventory.Find(inventorySlot => inventorySlot.Item == item);

        if (slotToClear == null) return false;

        inventory.Remove(slotToClear);
        slotToClear.Clear();
        slotsPool.Add(slotToClear);

        return true;
    }

    public bool RemoveItemFromInventorySlot(InventorySlotSO slot)
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

        List<InventorySlotSO> newInventory = new List<InventorySlotSO>(newCapacity);
        List<InventorySlotSO> newPool = new List<InventorySlotSO>(newCapacity);
        this.capacity = newCapacity;

        foreach (InventorySlotSO slot in inventory)
        {
            newInventory.Add(slot);
        }
        inventory = newInventory;

        int requiredSlots = newCapacity - usedSlots;

        foreach (InventorySlotSO slot in slotsPool)
        {
            if (requiredSlots > 0)
            {
                newPool.Add(slot);
                requiredSlots--;
            }
            else
            {
                Destroy(slot);
            }
        }

        for (int i = 0; i < requiredSlots; i++)
        {
            InventorySlotSO inventorySlot = CreateInstance<InventorySlotSO>();
            newPool.Add(inventorySlot);
        }

        slotsPool = newPool;

        return true;
    }

    public bool SwapItemsBetweenSlots(InventoryItemSO itemA, InventoryItemSO itemB)
    {
        if (itemA == null || itemB == null) return false;

        InventorySlotSO slotA = inventory.Find(inventorySlot => inventorySlot.Item == itemA);
        InventorySlotSO slotB = inventory.Find(inventorySlot => inventorySlot.Item == itemB);

        if (slotA == null || slotB == null) return false;

        slotB.SetItem(itemA);
        slotA.SetItem(itemB);

        return true;
    }
}
