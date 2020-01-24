using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    private InventoryManager inventoryManager;
    private ItemData itemData;

    [SerializeField]
    private Button slotButton;
    [SerializeField] 
    private Image itemImage;
    [SerializeField] 
    private TextMeshProUGUI amountText;

    public void SetSlotManager(InventoryManager _inventoryManager)
    {
        inventoryManager = _inventoryManager;
    }

    public void PopulateSlot(ItemData _item)
    {
        itemData = _item;

        itemImage.sprite = itemData.itemImage;
        amountText.text = itemData.stackCount.ToString();

        slotButton.onClick.RemoveAllListeners();
        slotButton.enabled = true;
        slotButton.onClick.AddListener(() => SlotClickResponse());
    }

    private void SlotClickResponse()
    {
        inventoryManager.PopulateItemViewer(itemData);
    }
}
