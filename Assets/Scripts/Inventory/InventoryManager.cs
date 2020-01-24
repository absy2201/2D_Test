using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    private Inventory inventory;

    [Header("For Invetory Handling")]
    [SerializeField]
    private GameObject inventorySlotPrefab;
    [SerializeField]
    private Transform inventorySlotContainer;

    [Header("For Item Viewer")]
    [SerializeField]
    private TextMeshProUGUI descriptionText;
    [SerializeField]
    private Image descriptionImage;
    [SerializeField]
    private Button useButton;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            Debug.Log(inventory.GetItems());
        }
    }

    public void SetInventory(Inventory _inventory)
    {
        inventory = _inventory;
    }

    public void PopulateInventory()
    {
        if(inventorySlotContainer.childCount > 0)
        {
            for (int i = 0; i < inventorySlotContainer.childCount; i++)
            {
                Destroy(inventorySlotContainer.GetChild(i).gameObject);
            }
        }

        List<ItemData> items = inventory.GetItems();

        for (int i = items.Count - 1; i >= 0; i--)
        {
            if(items[i].stackCount > 0)
            {
                GameObject temp = Instantiate(inventorySlotPrefab, inventorySlotContainer);

                temp.GetComponent<InventorySlot>().SetSlotManager(this.GetComponent<InventoryManager>());
                temp.GetComponent<InventorySlot>().PopulateSlot(items[i]);
            }
            else
            {
                inventory.RemoveItem(items[i]);
                PopulateItemViewer();
                continue;
            }
        }
    }

    public void PopulateItemViewer(ItemData _item = null)
    {
        if(_item == null)
        {
            descriptionText.text = "";
            descriptionImage.sprite = null;

            useButton.interactable = false;
            useButton.onClick.RemoveAllListeners();

            return;
        }
        else
        {
            descriptionText.text = _item.itemDescription;
            descriptionImage.sprite = _item.itemImage;

            useButton.onClick.RemoveAllListeners();

            switch (_item.GetItemType())
            {
                case ItemData.ItemType.None:
                    useButton.interactable = false;
                    return;

                case ItemData.ItemType.ConsumableItem:
                    ConsumableItemData _consumable = _item as ConsumableItemData;
                    _consumable.RegisterUseCallback();
                    useButton.onClick.AddListener(() => _consumable.UseItem());
                    useButton.interactable = true;
                    break;

                case ItemData.ItemType.QuestItem:
                    useButton.interactable = false;
                    return;
            }
        }  
    }
}
