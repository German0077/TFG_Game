using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public InventorySlot[] itemSlots;
    public int gold;
    public TMP_Text goldText;
    
    private void Start()
    {
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
        else {
            foreach (var slot in itemSlots) {
                if (slot.item == null) {
                    slot.item = item;
                    slot.quantity = quantity;
                    slot.UpdateUI();
                    return;
                }
            }
        }
    }
}
