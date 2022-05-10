using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] private int capacity = 5;
    [SerializeField] private InventorySlot inventorySlotPrefab;

    private InventorySlot[] inventory = null;
    private int unusedSlotsHeadIndex = -1;
    private int unusedSlotsTailIndex = -1;
    private int usedSlotsHeadIndex = -1;
    private int usedSlotsTailIndex = -1;
    private int occupiedSlots = 0;

    private void Start()
    {
        this.capacity = Mathf.Max(1, this.capacity);
        this.inventory = new InventorySlot[this.capacity];

        unusedSlotsHeadIndex = 0;
        unusedSlotsTailIndex = capacity - 1;
        usedSlotsHeadIndex = -1;
        usedSlotsTailIndex = -1;

        for (int i = 0; i < capacity; i++)
        {
            inventory[i] = Instantiate<InventorySlot>(inventorySlotPrefab, this.transform);
            inventory[i].nextSlotIndex = i + 1;
        }
        inventory[capacity - 1].nextSlotIndex = -1;

        occupiedSlots = 0;
    }

    public bool AddItemToInventoryEnd(InventoryItem item)
    {
        if (item == null) return false;

        int availableSlotIndex = PopUnusedSlot();
        if (availableSlotIndex == -1) return false;

        inventory[availableSlotIndex].SetItem(item);

        if (usedSlotsTailIndex == -1)
        {
            usedSlotsHeadIndex = availableSlotIndex;
            usedSlotsTailIndex = availableSlotIndex;
        }
        else
        {
            inventory[usedSlotsTailIndex].nextSlotIndex = availableSlotIndex;
            usedSlotsTailIndex = availableSlotIndex;
        }

        occupiedSlots++;

        return true;
    }

    public bool AddItemToInventoryIndex(InventoryItem item, int index)
    {
        if (item == null) return false;

        int availableSlotIndex = PopUnusedSlot();
        if (availableSlotIndex == -1) return false;

        inventory[availableSlotIndex].SetItem(item);

        index = Mathf.Clamp(index, 0, occupiedSlots);

        int i = 0;
        int previousIndex = -1;
        int currentIndex = usedSlotsHeadIndex;
        while (i != index)
        {
            previousIndex = currentIndex;
            currentIndex = inventory[currentIndex].nextSlotIndex;
            i++;
        }

        if (previousIndex == -1)
        {
            inventory[availableSlotIndex].nextSlotIndex = usedSlotsHeadIndex;

            usedSlotsHeadIndex = availableSlotIndex;

            if (usedSlotsTailIndex == -1)
            {
                usedSlotsTailIndex = availableSlotIndex;
            }
        }
        else
        {
            inventory[availableSlotIndex].nextSlotIndex = inventory[previousIndex].nextSlotIndex;

            inventory[previousIndex].nextSlotIndex = availableSlotIndex;

            if (inventory[availableSlotIndex].nextSlotIndex == -1)
            {
                usedSlotsTailIndex = availableSlotIndex;
            }
        }

        occupiedSlots++;

        return true;
    }

    public void PrintInventory()
    {
        string output = "";

        output += "Occupied Slots : " + occupiedSlots + "\n";

        output += "-- Unused : ";
        int i = unusedSlotsHeadIndex;
        while (i != -1)
        {
            output += "[" + i + "]";
            i = inventory[i].nextSlotIndex;
        }
        output += "\n";

        output += "-- Used : ";
        i = usedSlotsHeadIndex;
        while (i != -1)
        {
            output += "[" + i + "]";
            i = inventory[i].nextSlotIndex;
        }
        output += "\n";

        Debug.Log(output);
    }

    private int PopUnusedSlot()
    {
        if (unusedSlotsHeadIndex == -1) return -1;

        int availableSlotIndex = unusedSlotsHeadIndex;

        if (inventory[unusedSlotsHeadIndex].nextSlotIndex == -1)
        {
            unusedSlotsHeadIndex = -1;
            unusedSlotsTailIndex = -1;
        }
        else
        {
            unusedSlotsHeadIndex = inventory[unusedSlotsHeadIndex].nextSlotIndex;
        }

        inventory[availableSlotIndex].nextSlotIndex = -1;

        return availableSlotIndex;
    }
}
