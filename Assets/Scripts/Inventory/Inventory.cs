using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory
{
    private InventoryManager inventoryManager;
    private List<ItemData> allItems;

    public Inventory(InventoryManager _inventoryManager)
    {
        allItems = new List<ItemData>();
        inventoryManager = _inventoryManager;
    }

    public List<ItemData> GetItems()
    {
        return allItems;
    }

    public void AddItem(ItemData _item)
    {
        for (int i = 0; i < allItems.Count; i++)
        {
            if(allItems[i].itemName == _item.itemName)
            {
                allItems[i].stackCount += _item.stackCount;
                inventoryManager.PopulateInventory();
                return;
            }
        }

        allItems.Add(_item);
        inventoryManager.PopulateInventory();
    }

    public void RemoveItem(ItemData _item)
    {
        allItems.Remove(_item);
        inventoryManager.PopulateInventory();
    }
}