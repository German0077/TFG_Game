using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public Items item;
    public int quantity;

    public Image itemImage;
    public TMP_Text quantityText;

    public void UpdateUI()
    {
        if (item != null) {
            itemImage.sprite = item.icon;
            itemImage.gameObject.SetActive(true);
            quantityText.text = quantity.ToString();
        }
        else {
            itemImage.gameObject.SetActive(false);
            quantityText.text = "";
        }
    }
}
