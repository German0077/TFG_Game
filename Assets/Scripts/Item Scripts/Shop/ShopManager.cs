using UnityEngine;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [SerializeField] private ShopSlots[] shopSlots;

    [SerializeField] private InventoryManager inventory;

    public PlayerEquipment playerEquipment;
        
    public void FillShop (List<ShopItems> shopItems) {
        for (int i = 0; i < shopItems.Count && i < shopSlots.Length; i++) {
            ShopItems shopItem = shopItems[i];
            shopSlots[i].Initialize(shopItem.item, shopItem.price);
            shopSlots[i].gameObject.SetActive(true);
        }

        for (int i = shopItems.Count; i < shopSlots.Length; i++) {
            shopSlots[i].gameObject.SetActive(false);
        }
    }

    public void BuyItem (Items item, int price) {
        if (item != null && inventory.gold >= price) {
            if (item == playerEquipment.bowItem && playerEquipment.hasBow)
                return;
            if (item == playerEquipment.bowItem) {
                playerEquipment.hasBow = true;
                playerEquipment.EquipBow();
                inventory.gold -= price;
                inventory.goldText.text = inventory.gold.ToString();
                return;
            }
            if (ExistSpace(item)){
                inventory.gold -= price;
                inventory.goldText.text = inventory.gold.ToString();
                inventory.AddItem(item, 1);
            }
        }
    }

    public void SellItem(Items item) {
        if (item == null)
            return;
        foreach (var slot in shopSlots) {
            if (slot.item == item) {
                inventory.gold += slot.price;
                inventory.goldText.text = inventory.gold.ToString();
                return;
            }
        }
    }

    private bool ExistSpace(Items item) {
        foreach (var slot in inventory.itemSlots) {
            if (slot.item == item)
                return true;
            else if (slot.item == null)
                return true;
        }
        return false;
    }
}

[System.Serializable]
public class ShopItems
{
    public Items item;
    public int price;
}

