using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    
    public int currentHealth;
    public int maxHealth = 5;

    public SpriteRenderer playerSprite;
    public PlayerMovement playerMovement;
    public GameOver gameOverScreen;

    // Start is called once before the first execution of Update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void HealthChange(int amount) {
        currentHealth += amount;

        if (currentHealth <= 0) {
            playerSprite.enabled = false;
            playerMovement.enabled = false;
            gameOverScreen.ShowScreen();
            Time.timeScale = 0;
        }
    }
}
