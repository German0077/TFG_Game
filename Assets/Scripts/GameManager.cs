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

    private void FixAndDestroy() {
        foreach (GameObject obj in persistentObjects) {
            Destroy(obj);
        }
        Destroy(gameObject);
    }
}
