using UnityEngine;
using System.Collections;

public class UseItem : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public PlayerMovement playerMovement;
    public PlayerCombat playerCombat;
    
    public void ChangeStats(Items item) {
        if (item.currentHealth > 0)
            playerHealth.HealthChange(item.currentHealth);

        if (item.speed != 0)
            playerMovement.speed += item.speed;

        if (item.damage != 0)
            playerCombat.damage += item.damage;
        
        if (item.duration > 0)
            StartCoroutine(Timer(item, item.duration));
    }

    private IEnumerator Timer(Items item, float duration) {
        yield return new WaitForSeconds(duration);

        if (item.speed != 0)
            playerMovement.speed -= item.speed;

        if (item.damage != 0)
            playerCombat.damage -= item.damage;
    }
}