using UnityEngine;

public class vacaMu : MonoBehaviour
{
    private static GameObject vacaInstancia;
    public int contadorFrutas;
    private float distanciaInteraccion = 4f; // Rango
    private Transform jugador;

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
            //si hay frutas en el inventario se las come + pone mensaje de que tiene hambre
            PilaDeItem[] inventario = InventarioManager.GetInstance().inventario;

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

                        Debug.Log("la vaca se comio tus frutas");
                        pilaDeItem.item = null;
                        pilaDeItem.cantidad = 0;

                        InventarioManager.GetInstance().RebuildUiInventario();
                    }
                }

            }
        }

        if (contadorFrutas >= 50)
        {
            gameObject.GetComponent<MovimientoVaca>().sePuedoMover = true;
        }
    }

}
