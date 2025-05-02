using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private int faceDirection = 1;
    private EnemyState enemyState;
    
    private Rigidbody2D rb;
    private Transform player;
    private Animator animator;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyState == EnemyState.Move) {
            if (player.position.x > transform.position.x && faceDirection == -1 ||
                player.position.x < transform.position.x && faceDirection == 1)
            {
                Flip();
            }
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * speed; 
        }
    }

    void Flip() {
        faceDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (player == null) {
                player = collision.transform;
            }
            ChangeState(EnemyState.Move);   
        } 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);
        } 
    }

    void ChangeState(EnemyState newState) {
        
        //Exit animation
        if (enemyState == EnemyState.Idle) {
            animator.SetBool("isIdle", false);

        } else if (enemyState == EnemyState.Move) {
            animator.SetBool("isMoving", false);
        }

        //Update state
        enemyState = newState;

        //Update animation
        if (enemyState == EnemyState.Idle) {
            animator.SetBool("isIdle", true);

        } else if (enemyState == EnemyState.Move) {
            animator.SetBool("isMoving", true);
        }
    }
}

public enum EnemyState {Idle, Move}