using UnityEngine;

public class ElevationEntry : MonoBehaviour
{
    public Collider2D[] elevationColliders;
    public Collider2D[] borderColliders;

    private void OnTriggerEnter2D(Collider2D collision) {

        if (collision.gameObject.tag == "Player") {
            
            foreach (Collider2D elevation in elevationColliders){
                elevation.enabled = false;
            }

            foreach (Collider2D border in borderColliders){
                border.enabled = true;
            }

            collision.gameObject.GetComponent<SpriteRenderer>().sortingOrder = 15;        
        }
    }
}
