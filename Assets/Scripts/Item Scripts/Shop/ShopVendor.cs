using UnityEngine;
using System;
using System.Collections.Generic;

public class ShopVendor : MonoBehaviour
{
    public Animator animator;
    private bool playerClose;

    public CanvasGroup shopCanvas;
    public ShopManager shop;
    private bool shopOpen;

    public static event Action<ShopManager, bool> ShopToggled;

    [SerializeField] private List<ShopItems> shopItems;
    [SerializeField] private List<ShopItems> shopWeapons;

    void Update()
    {
        if (playerClose) {
            if (Input.GetButtonDown("Interact")) {
                if (!shopOpen) {
                    Time.timeScale = 0;
                    shopOpen = true;
                    ShopToggled?.Invoke(shop, true);
                    shopCanvas.alpha = 1;
                    shopCanvas.blocksRaycasts = true;
                    shopCanvas.interactable = true;
                    OpenItemShop();
                } else {
                    Time.timeScale = 1;
                    shopOpen = false;
                    ShopToggled?.Invoke(shop, false);
                    shopCanvas.alpha = 0;
                    shopCanvas.blocksRaycasts = false;
                    shopCanvas.interactable = false;
                }
            }
        }
    }

    public void OpenItemShop() {
        shop.FillShop(shopItems);
    }

    public void OpenWeaponShop() {
        shop.FillShop(shopWeapons);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            animator.SetBool("playerClose", true);
            playerClose = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            animator.SetBool("playerClose", false);
            playerClose = false;
        }
    }
}
