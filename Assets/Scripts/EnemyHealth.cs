using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int currentHealth;
    public int maxHealth = 5;

    // Start is called once before the first execution of Update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void HealthChange(int amount) {
        currentHealth += amount;

        if (currentHealth <= 0) {
            Destroy(gameObject);
        }
    }
}
