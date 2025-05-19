using UnityEngine;

public class PlayerBow : MonoBehaviour
{
    public Transform launchPoint;
    public GameObject arrowPrefab;
    private Vector2 aimDirection = Vector2.right;

    public float cooldown = 0.5f;
    private float timer;

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        
        Aiming();
                
        if (Input.GetButtonDown("Bow_Attack") && timer <= 0) { 
            Shoot();
        }
    }

    private void Aiming() {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        if(horizontal != 0 || vertical !=0) {
            aimDirection = new Vector2(horizontal, vertical).normalized;
        }
    }

    public void Shoot() {
        Arrow arrow = Instantiate(arrowPrefab, launchPoint.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.direction = aimDirection;
        timer = cooldown;
    }

}
