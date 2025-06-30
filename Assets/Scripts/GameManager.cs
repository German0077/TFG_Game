using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Persistent Objects")]
    public GameObject[] persistentObjects;

    [Header("Cached References")]
    public CanvasGroup canvasGroup;
    public ShopManager shopManager; 
    public ShopVendor shopVendor;

    [Header("Victory Settings")]
    public int killsToWin;
    private int currentKills;
    public GameOver gameOverScreen;

    private void Awake() {
        if (Instance != null) {
            FixAndDestroy();
            return;
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            MarkPersistentObjects();
        }
    }

    private void MarkPersistentObjects() {
        foreach (GameObject obj in persistentObjects) {
            if (obj != null) {
                DontDestroyOnLoad(obj);
            }
        }
    }

    public void FixAndDestroy() {
        foreach (GameObject obj in persistentObjects) {
            Destroy(obj);
        }
        Destroy(gameObject);
    }

    public void AddKill() {
        currentKills++;
        if (currentKills >= killsToWin && gameOverScreen != null) {
            gameOverScreen.ShowScreen();
            Time.timeScale = 0;
        }
    }
}
