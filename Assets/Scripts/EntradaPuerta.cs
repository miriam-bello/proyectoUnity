using UnityEngine;
using UnityEngine.SceneManagement;

public class EntradaPuerta : MonoBehaviour
{
    private static GameObject playerInstance;
    public static EntradaPuerta Instance;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            SceneManager.LoadScene("SceneCasa");

        }
    }

}
