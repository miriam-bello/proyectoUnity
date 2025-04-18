using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorMenu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Jugar()
    {
        //cargar escena
        SceneManager.LoadScene("SceneGranja");
    }

    public void Creditos()
    {
        //cargar escena
       SceneManager.LoadScene("SceneCreditos");
    }

    public void Menu()
    {
        //cargar escena
        SceneManager.LoadScene("SceneMenuPrincipal");
    }

    public void Salir()
    {
        //cargar escena
        Application.Quit();
    }
}
