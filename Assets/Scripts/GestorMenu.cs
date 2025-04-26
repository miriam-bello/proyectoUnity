using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorMenu : MonoBehaviour
{



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Jugar()
    {
        DestroyGameManager();
        //cargar escena
        SceneManager.LoadScene("SceneGranja");
    }

    public void Creditos()
    {
        DestroyGameManager();
        //cargar escena
        SceneManager.LoadScene("SceneCreditos");
    }

    public void Menu()
    {
        DestroyGameManager();
        //cargar escena
        SceneManager.LoadScene("SceneMenuPrincipal");
    }

    public void Salir()
    {
        //cargar escena
        Application.Quit();
    }

    public void DestroyGameManager()
    {
        Destroy(GameObject.FindWithTag("GameManager"));
        Destroy(GameObject.FindWithTag("Player"));

    }
}
