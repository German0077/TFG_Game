using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class ShopSlots : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Items item;
    public TMP_Text nameText;
    public TMP_Text priceText;
    public Image itemImage;
    
    public int price;
    
    [SerializeField] private ShopManager shop;
    [SerializeField] private ShopInfo shopInfo;

    public void Initialize(Items newItem, int price) {
        item = newItem;
        itemImage.sprite = item.icon;
        nameText.text = item.itemName;
        this.price = price;
        priceText.text = price.ToString();
    }

    public void OnBuyClicked() {
        shop.BuyItem(item, price);
    }

    public void OnPointerEnter(PointerEventData eventData) {
        shopInfo.ShowInfo(item);
    }

    public void OnPointerExit(PointerEventData eventData) {
        shopInfo.HideInfo();
    }
}
