using UnityEngine;

public class Arrow : MonoBehaviour
{
    
    public Rigidbody2D rb;
    public Vector2 direction = Vector2.right;
    public float lifeSpan = 2;
    public float speed;

    public LayerMask enemyLayer;

    public int damage;
    public float knockBackForce;
    public float knockBackTime;
    public float stunTime;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb.linearVelocity = direction * speed;
        RotateArrow();
        Destroy(gameObject, lifeSpan);
    }

    private void RotateArrow() {
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if((enemyLayer.value &(1 << collision.gameObject.layer)) > 0) {
            collision.gameObject.GetComponent<EnemyHealth>().HealthChange(-damage);
            collision.gameObject.GetComponent<EnemyMovement>().Knockback(transform, knockBackForce, knockBackTime, stunTime);
        }
    }
}
