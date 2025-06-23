using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public UseItem useItem;
    public int gold;
    public TMP_Text goldText;
    public Items weapon;
    public GameObject lootPrefab;
    public Transform player;
    
    private void Start()
    {
        if (weapon != null) {
            itemSlots[0].item = weapon;
            itemSlots[0].quantity = 1;
        }
        
        foreach (var slot in itemSlots) {
            slot.UpdateUI();
        }
    }

    private void OnEnable() {
        Loot.OnItemCollected += AddItem;
    }

    private void OnDisable() {
        Loot.OnItemCollected -= AddItem;
    }

    public void AddItem(Items item, int quantity) {
        if (item.isGold) {
            gold += quantity;
            goldText.text = gold.ToString();
            return;
        }

        foreach (var slot in itemSlots) {
            if (slot.item == item) {
                slot.quantity += quantity;
                slot.UpdateUI();
                return;
            }
            else if (slot.item == null && !slot.isWeaponSlot) {
                slot.item = item;
                slot.quantity = quantity;
                slot.UpdateUI();
                return;
            }
        }

        DropLoot(item, quantity);
    }

    public void DropItem(InventorySlot slot) {
        DropLoot(slot.item, 1);
        slot.quantity--;
        if (slot.quantity <= 0) {
            slot.item = null;
        }
        slot.UpdateUI();
    }

    private void DropLoot(Items item, int quantity) {
        Loot loot = Instantiate(lootPrefab, player.position, Quaternion.identity).GetComponent<Loot>();
        loot.Spawn(item, quantity, false);
    }

    public void UseItem(InventorySlot slot) {
        if (slot.item != null && slot.quantity >= 0) {
            useItem.ChangeStats(slot.item);
            slot.quantity--;
            if (slot.quantity <= 0)
            {
                slot.item = null;
            }
            slot.UpdateUI();
        }
    }

    public void ChangeWeapon(Items weapon) {
        itemSlots[0].item = weapon;
        itemSlots[0].quantity = 1;
        itemSlots[0].UpdateUI();
    }
}
