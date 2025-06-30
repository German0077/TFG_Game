using UnityEngine;
using Unity.Cinemachine;
using UnityEngine.SceneManagement;

public class ConfinerFinder : MonoBehaviour
{
    private void OnEnable() {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDisable() {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode) {
        var confiner = GetComponent<CinemachineConfiner2D>();
        var polygonCollider = GameObject.FindWithTag("Confiner").GetComponent<PolygonCollider2D>();
        confiner.BoundingShape2D = polygonCollider;
    }
}
