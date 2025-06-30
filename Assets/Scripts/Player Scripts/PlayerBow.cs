using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject arrowPrefab;
    private Vector2 aimDirection = Vector2.right;
    private Vector2 shootDirection;

    public PlayerMovement playerMovement;

    public float cooldown = 0.5f;
    private float timer;

    public Animator animator;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        Aiming();
                
        if (Input.GetButtonDown("Attack") && timer <= 0) { 
           playerMovement.isShooting = true;
           animator.SetBool("isShooting", true);
           shootDirection = aimDirection;
        }
    }

    private void OnEnable() {
        animator.SetLayerWeight(0, 0);
        animator.SetLayerWeight(1, 1);
    }

    private void OnDisable() {
        animator.SetLayerWeight(0, 1);
        animator.SetLayerWeight(1, 0);
    }

    private void Aiming() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical !=0) {
            aimDirection = new Vector2(horizontal, vertical).normalized;
            animator.SetFloat("aimX", aimDirection.x);
            animator.SetFloat("aimY", aimDirection.y);
        }
    }

    public void Shoot() {
        if (timer <= 0 ) {
            float offset = 0.4f; // Pequeña separación
            Vector2 spawnPosition = (Vector2)launchPoint.position + shootDirection * offset;

            Arrow arrow = Instantiate(arrowPrefab, spawnPosition, Quaternion.identity).GetComponent<Arrow>();
            arrow.direction = shootDirection;
            
            int playerOrder = playerMovement.GetComponent<SpriteRenderer>().sortingOrder;
            arrow.GetComponent<SpriteRenderer>().sortingOrder = playerOrder;

            timer = cooldown;
        }
        animator.SetBool("isShooting", false);
        playerMovement.isShooting = false;
    }

}
