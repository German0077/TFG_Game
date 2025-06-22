using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
    public Items item;
    public int quantity;
    public bool isWeaponSlot;

    public Image itemImage;
    public TMP_Text quantityText;

    public InventoryManager inventory;

    private void Start() {
        inventory = GetComponentInParent<InventoryManager>();
    }

    public void OnPointerClick(PointerEventData eventData) {
        if (quantity > 0 && !isWeaponSlot) {
            if (eventData.button == PointerEventData.InputButton.Left) {
                inventory.UseItem(this);
            }
            else if (eventData.button == PointerEventData.InputButton.Right) {
                inventory.DropItem(this);
            }
        }
    }
    
    public void UpdateUI()
    {
        if (item != null) {
            itemImage.sprite = item.icon;
            itemImage.gameObject.SetActive(true);

            if (!isWeaponSlot) {
                quantityText.text = quantity.ToString();
            }
            else {
                quantityText.text = "";
            }
        }
        else {
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }
}
