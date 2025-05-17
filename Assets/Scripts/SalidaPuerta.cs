using UnityEngine;
using UnityEngine.SceneManagement;

public class SalidaPuerta : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            GameManager.GetInstance().Granja();
        }
    }

}
