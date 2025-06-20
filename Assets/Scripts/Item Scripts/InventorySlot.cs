using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Items item;
    public int quantity;
    public bool isWeaponSlot;

    public Image itemImage;
    public TMP_Text quantityText;

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
