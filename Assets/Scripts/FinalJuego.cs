using UnityEngine;

public class FinalJuego : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            GameManager.GetInstance().Final();
        }
    }
}
