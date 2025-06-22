using UnityEngine;
using System;

public class Loot : MonoBehaviour
{
    public Items item;
    public SpriteRenderer itemSprite;
    public Animator animator;

    public bool canCollect = true;
    public int quantity;
    public static event Action<Items, int> OnItemCollected;

    private void OnValidate() {
        if (item == null ) {
            return;
        }
        UpdateAppearance();
    }

    public void Spawn(Items item, int quantity) {
        this.item = item;
        this.quantity = quantity;
        canCollect = false;
        UpdateAppearance();
    }

    private void UpdateAppearance() {
        itemSprite.sprite = item.icon;
        this.name = item.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player") && canCollect == true) {
            animator.Play("ItemCollect");
            OnItemCollected?.Invoke(item, quantity);
            Destroy(gameObject, .5f);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)  {
        if (collision.CompareTag("Player")) {
            canCollect = true;
        }
    }
}
