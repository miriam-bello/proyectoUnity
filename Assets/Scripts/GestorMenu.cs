using UnityEngine;
using UnityEngine.SceneManagement;

public class GestorMenu : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void Jugar()
    {
        //cargar escena
        GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.Jugar();
    }

    public void Creditos()
    {
        //cargar escena
        GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.Creditos();
    }

    public void Menu()
    {
        //cargar escena
        GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.Menu();
    }

    public void Salir()
    {
        //cargar escena
        GameManager gameManager = GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
        gameManager.Salir();
    }

 
}
