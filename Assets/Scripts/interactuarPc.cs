using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Fuerza a tener Collider2D

public class InteractuarPc : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    [SerializeField] private float distanciaInteraccion = 3f; // Rango

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
        if (distancia <= distanciaInteraccion)
        {
            tutorial.GetComponent<Canvas>().enabled = true;
        }
    }

    //cuando pasas el raton por encima el borde
    [SerializeField] private GameObject borde;
    private void OnMouseEnter() => borde.GetComponent<SpriteRenderer>().enabled = true;
    private void OnMouseExit() => borde.GetComponent<SpriteRenderer>().enabled = false;

}
