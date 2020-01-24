using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "NewQuestItemData", menuName = "Items/QuestItemData", order = 50)]
public class QuestItemData : ItemData
{
    public QuestItemData()
    {
        itemName = "New Quest Item";
        itemDescription = "New Quest Item Description";
        itemImage = null;
        stackCount = 0;
        itemType = ItemType.QuestItem;
    }

    public enum QuestItemType
    {
        None,
        Key,
        Urn,
        Orb,
        Crystal
    }
    public QuestItemType questItemType = QuestItemType.None;

    public QuestItemType GetQuestItemType()
    {
        return questItemType;
    }

    [Space(20)]
    public UnityEvent submitEvent;
    
    public void SubmitItem()
    {
        submitEvent.Invoke();
    }
}