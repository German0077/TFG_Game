using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneChange : MonoBehaviour
{
    public string NewScene;
    public Animator animator;
    public float fadeTime = .5f;

    public Canvas fadeCanvas;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag == "Player") {
            if (fadeCanvas != null) {
                fadeCanvas.sortingOrder = 1;
            }
            animator.Play("BlackFade");
            StartCoroutine(Delay());
            
        }
    }

    IEnumerator Delay() {
        yield return new WaitForSeconds(fadeTime);
        SceneManager.LoadScene(NewScene);
    }
}
