using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Animator animator;
    
    public float cooldown = 0.5f;
    private float timer;

    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    
    public LayerMask enemyLayer;

    public float knockBackForce;
    public float knockBackTime;
    public float stunTime;


    void Update()
    {
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
    }

    public void Attack() {
        if (timer <= 0 && enabled) {
            animator.SetBool("isAttacking", true);
            timer = cooldown;
        }
        
    }

    public void DealDamage() {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, enemyLayer);
        if (enemies.Length > 0) {
            enemies[0].GetComponent<EnemyHealth>().HealthChange(-damage);
            enemies[0].GetComponent<EnemyMovement>().Knockback(transform, knockBackForce, knockBackTime, stunTime);
        }
    }

    public void FinishAttack() {
        animator.SetBool("isAttacking", false);
    }
}

