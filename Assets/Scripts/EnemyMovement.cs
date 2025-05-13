//EnemyMovement.cs

using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float attackRange = 2;
    public float cooldown = 1f;

    private float timer;
    private int faceDirection = 1;   
    private EnemyState enemyState;
    
    private Rigidbody2D rb;
    private Transform player;
    private Animator animator;

    public float playerDetectRange = 5;
    public Transform detectionPoint;
    public LayerMask playerLayer;
    
    
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
        if (timer > 0) {
            timer -= Time.deltaTime;
        }
        
        CheckForPlayer();

        if (enemyState == EnemyState.Move) {
            Move();
        }
        else if (enemyState == EnemyState.Attack) {
            rb.linearVelocity = Vector2.zero;
        }
    }

    void Move() {

        if (player.position.x > transform.position.x && faceDirection == -1 ||
                player.position.x < transform.position.x && faceDirection == 1)
        {
            Flip();
        }
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed;
    }

    void Flip() {
        faceDirection *= -1;
        transform.localScale = new Vector3 (transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
    }

    private void CheckForPlayer() {
        
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectRange, playerLayer);
        
        if (hits.Length > 0) {
            player = hits[0].transform;
             
            if (Vector2.Distance(transform.position, player.position) <= attackRange && timer <= 0) {
                timer = cooldown;
                ChangeState(EnemyState.Attack);  
            }

            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attack) {
                ChangeState(EnemyState.Move);   
            }
            
        } else {
            rb.linearVelocity = Vector2.zero;
            ChangeState(EnemyState.Idle);  
        }
    }

    void ChangeState(EnemyState newState) {
        
        //Exit animation
        if (enemyState == EnemyState.Idle) {
            animator.SetBool("isIdle", false);

        } 
        else if (enemyState == EnemyState.Move) {
            animator.SetBool("isMoving", false);
        }
        else if (enemyState == EnemyState.Attack) {
            animator.SetBool("isAttacking", false);
        }

        //Update state
        enemyState = newState;

        //Update animation
        if (enemyState == EnemyState.Idle) {
            animator.SetBool("isIdle", true);

        } 
        else if (enemyState == EnemyState.Move) {
            animator.SetBool("isMoving", true);
        }
        else if (enemyState == EnemyState.Attack) {
            animator.SetBool("isAttacking", true);
        }
    }

    // Painting a Red circle just for radius detection testing
    private void OnDrawGizmosSelected() {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectRange);

    }
}

public enum EnemyState {Idle, Move, Attack}