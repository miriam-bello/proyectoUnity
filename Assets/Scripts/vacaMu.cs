using UnityEngine;

public class vacaMu : MonoBehaviour
{
    public int contadorFrutas;
    [SerializeField] private float distanciaInteraccion = 4f; // Rango

    private Transform jugador;

    private void Start()
    {
        //buscamos la posicion del jugador
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }


    private void OnMouseDown()
    {
        //calcula la distancia
        float distancia = Vector2.Distance(
            new Vector2(transform.position.x, transform.position.y),
            new Vector2(jugador.position.x, jugador.position.y)
        );

        //activa el cartel cual haces click si la distancia es menor o igual al Rango(3f)
        if (distancia <= distanciaInteraccion)
        {
            Debug.Log("La vaca: mu!, la misma vaca: mu!");
        }
    }
}
