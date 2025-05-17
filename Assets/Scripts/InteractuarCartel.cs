using UnityEngine;
using UnityEngine.UI;

public class InteractuarCartel2D : MonoBehaviour
{
    private static GameObject instance;
    [SerializeField] private GameObject cartel;
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

        //activa el cartel cual haces click si la distancia es menor o igual al Rango(3f)
        if (distancia <= distanciaInteraccion)
        {
            cartel.GetComponent<Canvas>().enabled = true;
        }
    }
   // para hover
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color hoverColor = Color.yellow; // Color al hacer hover
    public Vector2 hoverScale = new Vector2(1.1f, 1.1f);

    void OnMouseEnter()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        spriteRenderer.color = hoverColor;
        transform.localScale = hoverScale;
    }

    void OnMouseExit()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = originalColor;
        transform.localScale = Vector3.one; // Escala normal (1, 1, 1)
    }
}