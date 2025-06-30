using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChange : MonoBehaviour
{
    public string NewScene;
    public Animator animator;
    public float fadeTime = .5f;

    public Vector2 newPlayerPosition;
    private Transform player;

    public Canvas fadeCanvas;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (fadeCanvas != null) {
                fadeCanvas.sortingOrder = 10;
            }
            player = collision.transform;
            animator.Play("BlackFade");
            StartCoroutine(Delay());
            
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(fadeTime);
        
        if (GameManager.Instance != null && GameManager.Instance.shopVendor != null) {
        GameManager.Instance.shopVendor.gameObject.SetActive(NewScene == "SampleScene");
        }
        
        player.position = newPlayerPosition;
        SceneManager.LoadScene(NewScene);
    }
}
