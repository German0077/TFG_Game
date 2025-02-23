using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float speed = 5;
    public int faceDirection = 1;
    
    public Rigidbody2D rb;
    public Animator animator;

    // FixedUpdate is called 50x per frame
    void FixedUpdate()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (horizontal > 0 && transform.localScale.x < 0 || horizontal < 0 && transform.localScale.x > 0) {
            Flip();
        }

        animator.SetFloat("horizontal", Mathf.Abs(horizontal));
        animator.SetFloat("vertical", Mathf.Abs(vertical));

        rb.linearVelocity = new Vector2(horizontal, vertical) * speed;
    }

    void Flip(){
        faceDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }
}
