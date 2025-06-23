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
    private static ShopManager activeShop;

    private void Start() {
        inventory = GetComponentInParent<InventoryManager>();
    }

    private void OnEnable() {
        ShopVendor.ShopToggled += ToggleShopUI;
    }

    private void OnDisable() {
        ShopVendor.ShopToggled -= ToggleShopUI;
    }

    private void ToggleShopUI(ShopManager shop, bool isOpen) {
        activeShop = isOpen ? shop: null;

    }

    public void OnPointerClick(PointerEventData eventData) {
        if (quantity > 0 && !isWeaponSlot) {
            if (eventData.button == PointerEventData.InputButton.Left) {
                if (activeShop != null) {
                    activeShop.SellItem(item);
                    quantity--;
                    UpdateUI();
                }
                else {
                    inventory.UseItem(this);
                }
            }
            else if (eventData.button == PointerEventData.InputButton.Right) {
                if (activeShop == null) {
                    inventory.DropItem(this);
                }
            }
        }
    }
    
    public void UpdateUI()
    {
        if (quantity <= 0) {
            item = null;
        }
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
