using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 5;
    public int faceDirection = 1;
    
    public Rigidbody2D rb;
    public Animator animator;

    public PlayerCombat playerCombat;

    private bool isKnockedBack;

    void Update() {
        if (Input.GetButtonDown("Sword_Attack")) { 
            playerCombat.Attack();
        }
    }

    // FixedUpdate is called 50x per second
    void FixedUpdate()
    {
        if (isKnockedBack == false) {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0) {
                Flip();
            }

            animator.SetFloat("horizontal", Mathf.Abs(horizontal));
            animator.SetFloat("vertical", Mathf.Abs(vertical));

            rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
        }
    }

    void Flip() {
        faceDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    public void Knockback(Transform enemy, float force, float stunTime) {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        rb.linearVelocity = direction * force;
        StartCoroutine(KnockbackCounter(stunTime));
    }

    IEnumerator KnockbackCounter(float stunTime) {
        yield return new WaitForSeconds(stunTime);
        rb.linearVelocity = Vector2.zero;
        isKnockedBack = false;
    }
}
