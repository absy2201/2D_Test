using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewConsumableItemData", menuName = "Items/ConsumableItemData", order = 50)]
public class ConsumableItemData : ItemData
{
    public ConsumableItemData()
    {
        itemName = "New Consumable Item";
        itemDescription = "New Consumable Item Description";
        itemImage = null;
        stackCount = 0;
        itemType = ItemType.ConsumableItem;
    }

    public enum ConsumableItemType
    {
        None,
        Health,
        Mana,
        Stamina
    }
    public ConsumableItemType consumableItemType = ConsumableItemType.None;

    [Space]
    public int effectValue = 0;

    public ConsumableItemType GetConsumableItemType()
    {
        return consumableItemType;
    }

    [Space(20)]
    public UnityEvent useEvent;

    public void UseItem()
    {
        useEvent.Invoke();
        stackCount--;  
    }

    public void RegisterUseCallback()
    {
        useEvent.RemoveAllListeners();

        switch(consumableItemType)
        {
            case ConsumableItemType.None:
                break;
            case ConsumableItemType.Health:
                break;
            case ConsumableItemType.Mana:
                break;
            case ConsumableItemType.Stamina:
                break;
        }

        useEvent.AddListener(() => FindObjectOfType<InventoryManager>().PopulateInventory());
    }
}