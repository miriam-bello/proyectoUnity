using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorPausa : MonoBehaviour
{
    [SerializeField] private GameObject MenuPausa;
    private bool juegoPausado = false;


    private void Update()
    {
        Debug.Log("Intentando pausar..."); // Mensaje de depuración
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (juegoPausado) Reanudar();
            else Pausa();
        }
    }

    public void Pausa()
    {
        Debug.Log("Intentando pausar..."); // Mensaje de depuración

        if (MenuPausa != null)
        {
            MenuPausa.GetComponent<Canvas>().enabled = true;
            juegoPausado = true;
            Time.timeScale = 0f;
            Cursor.visible = true;
            Debug.Log("Juego pausado correctamente");
        }
        else
        {
            Debug.LogError("No se puede pausar: MenuPausa es null");
        }
    }

    public void Reanudar()
    {
        MenuPausa.GetComponent<Canvas>().enabled = false;
        juegoPausado = false;
        Time.timeScale = 1f;
        Cursor.visible = false;
    }

    public void Salir()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("SceneMenuPrincipal");
    }
}