using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorPausa : MonoBehaviour
{
    //para pausar el personaje
    private GameObject personaje;
    private bool personajeDesactivar = true;
    private bool scriptsDeshabilitar = true;
    private MonoBehaviour[] scriptsPersonaje;

    //para sacar el menu de pausa y pausar el tiempo
    [SerializeField] private GameObject MenuPausa;
    private bool juegoPausado = false;

    private void Awake()
    {
        personaje  = GameObject.FindWithTag("Player");
        // Obtener todos los scripts del personaje si existe
        if (personaje != null && scriptsDeshabilitar)
        {
            scriptsPersonaje = personaje.GetComponents<MonoBehaviour>();
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado) Reanudar();
            else Pausa();
        }
    }

    public void Pausa()
    {
        if (MenuPausa != null)
        {
            MenuPausa.GetComponent<Canvas>().enabled = true;
            juegoPausado = true;
            Time.timeScale = 0f;

            // Desactivamos el personaje
            if (personajeDesactivar && personaje != null)
            {
                if (personajeDesactivar)
                {
                    foreach (var script in scriptsPersonaje)
                    {
                        if (script != this && script != null)
                            script.enabled = false;
                    }
                }
                else
                {
                    personaje.SetActive(false);
                }
            }

        }
        else
        {
            Debug.LogError("No se puede pausar");
        }
        
    }

    public void Reanudar()
    {
        MenuPausa.GetComponent<Canvas>().enabled = false;
        juegoPausado = false;
        Time.timeScale = 1f;

        // Volvemos a activar el personaje
        if (personajeDesactivar && personaje != null)
        {
            if (personajeDesactivar)
            {
                foreach (var script in scriptsPersonaje)
                {
                    if (script != null)
                        script.enabled = true;
                }
            }
            else
            {
                personaje.SetActive(true);
            }
        }

    }

    public void Salir()
    {
        //cargar escena
        GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.Menu();
    }
}