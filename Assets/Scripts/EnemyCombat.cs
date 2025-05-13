
//EnemyCombat.cs

using UnityEngine;

public class EnemyCombat : MonoBehaviour
{

    public int damage = 1;
    public Transform attackPoint;
    public float weaponRange;
    public float knockBackForce;
    public float stunTime;

    public LayerMask playerLayer;

    /*
    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "Player") {
            collision.gameObject.GetComponent<PlayerHealth>().HealthChange(-damage);
        }
    }
    */

    public void Attack() {
        Collider2D[] hits = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);

        if (hits.Length > 0) {
            hits[0].GetComponent<PlayerHealth>().HealthChange(-damage);
            hits[0].GetComponent<PlayerMovement>().Knockback(transform, knockBackForce, stunTime);
        }
    }

    // Painting a Red circle just for radius detection testing
    private void OnDrawGizmosSelected() {
        if (attackPoint == null) return;
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, weaponRange);
    }
}