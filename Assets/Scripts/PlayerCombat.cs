using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    
    public float cooldown = 0.5f;
    private float timer;

    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
    }

    public void Attack() {
        if (timer <= 0) {
            animator.SetBool("isAttacking", true);
            timer = cooldown;
        }
        
    }

    public void FinishAttack() {
        animator.SetBool("isAttacking", false);
    }
}

