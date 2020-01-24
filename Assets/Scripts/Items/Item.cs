using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField]
    private ItemData itemData;

    private Collider2D triggerCollider;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        triggerCollider = GetComponent<Collider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        PopulateItem();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            Pickup(FindObjectOfType<PlayerController>().GetPlayerInventory());
        }
    }

    private void PopulateItem()
    {
        spriteRenderer.sprite = itemData.itemImage;
        triggerCollider.isTrigger = true;
    }

    private void Pickup(Inventory _inventory)
    {
        ItemData item = Instantiate(itemData);

        _inventory.AddItem(item);
        Destroy(gameObject);
    }
}
