using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 5;

    public Items gold;
    public int goldAmount;
    public GameObject lootPrefab;

    // Start is called once before the first execution of Update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void HealthChange(int amount) {
        currentHealth += amount;

        if (currentHealth <= 0) {
            Destroy(gameObject);
            DropLoot(gold, goldAmount);
        }
    }

    private void DropLoot(Items item, int quantity) {
        Loot loot = Instantiate(lootPrefab, transform.position, Quaternion.identity).GetComponent<Loot>();
        loot.Spawn(item, quantity, true);
    }
}
