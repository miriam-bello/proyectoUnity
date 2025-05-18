using UnityEngine;

public class vacaMu : MonoBehaviour
{
    private static GameObject vacaInstancia;
    public int contadorFrutas;
    private float distanciaInteraccion = 4f; // Rango
    private Transform jugador;
    private AudioSource audioSource;

    private void Start()
    {
        //buscamos la posicion del jugador
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    private void Awake()
    {
        if (vacaInstancia != null)
        {
            Destroy(gameObject);
            return;
        }

        //para solo tener un inventario singleton
        vacaInstancia = gameObject;

        DontDestroyOnLoad(gameObject);
        audioSource = GetComponent<AudioSource>();
    }


    private void OnMouseDown()
    {

        //calcula la distancia
        float distancia = Vector2.Distance(
                new Vector2(transform.position.x, transform.position.y),
                new Vector2(jugador.position.x, jugador.position.y)
        );

        //si esta lejos nah de nah
        if (distancia > distanciaInteraccion)
        {
            return;
        }


        //efecto sonido para la vaca
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }


        //si hay frutas en el inventario se las come + pone mensaje de que tiene hambre
        PilaDeItem[] inventario = InventarioManager.GetInstance().inventario;
        bool haComido = false;

        foreach (PilaDeItem pilaDeItem in inventario)
        {
            if (pilaDeItem.item != null)
            {
                if (pilaDeItem.item.itemNombre == "Cerezarpas" ||
                    pilaDeItem.item.itemNombre == "Nyantomato" ||
                    pilaDeItem.item.itemNombre == "Nyanzana" ||
                    pilaDeItem.item.itemNombre == "Purrrengena")
                {

                    contadorFrutas = contadorFrutas + pilaDeItem.cantidad;

                    pilaDeItem.item = null;
                    pilaDeItem.cantidad = 0;
                    InventarioManager.GetInstance().RebuildUiInventario();

                    haComido = true;

                }
            }

        }


        if (QuiereMasFruta())
        {
            if (haComido) { ManagerDialogos.GetInstance().MostrarMensaje("La vaca se comio tus frutas, que cara dura! Sigue con hambre"); }
            else
            {
                ManagerDialogos.GetInstance().MostrarMensaje("La nekovaca parece hambrienta");
            }
        }


        if (!QuiereMasFruta())
        {
            gameObject.GetComponent<MovimientoVaca>().sePuedoMover = true;
        }


    }

    public bool QuiereMasFruta()
    {
        return contadorFrutas < 50;
    }

}
