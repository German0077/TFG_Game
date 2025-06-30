using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void ShowScreen() {
        gameObject.SetActive(true);
    }

    public void RestartButton() {
        Time.timeScale = 1;
        if (GameManager.Instance != null) {
            GameManager.Instance.FixAndDestroy();
        }
        SceneManager.LoadScene("SampleScene");
        gameObject.SetActive(false);
    }

    public void MenuButton() {
        Time.timeScale = 1;
        if (GameManager.Instance != null) {
            GameManager.Instance.FixAndDestroy();
        }
        SceneManager.LoadScene("MenuScene");
        gameObject.SetActive(false);
    }
}
