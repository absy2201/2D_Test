using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ItemData : ScriptableObject
{
    public enum ItemType
    {
        None,
        ConsumableItem,
        QuestItem
    }

    public string itemName;
    public string itemDescription;
    public Sprite itemImage;
    public int stackCount;

    protected ItemType itemType;

    public ItemType GetItemType()
    {
        return itemType;
    }
}