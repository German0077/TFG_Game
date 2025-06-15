using UnityEngine;
using System;

public class Loot : MonoBehaviour
{
    public Items item;
    public SpriteRenderer itemSprite;
    public Animator animator;

    public int quantity;
    public static event Action<Items, int> OnItemCollected;

    private void OnValidate() {
        if (item == null ) {
            return;
        }
        itemSprite.sprite = item.icon;
        this.name = item.itemName;
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Player")) {
            animator.Play("ItemCollect");
            OnItemCollected?.Invoke(item, quantity);
            Destroy(gameObject, .5f);
        }
    }
}
