using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject gameManegerInstance;
    public DateTime time = new DateTime(1993, 1, 2, 7, 0, 0);

    //para que el solo haya un objeto gameManeger
    private void Awake()
    {
        // Si ya hay un gameManeger, destruye este objeto para evitar duplicados
        if (gameManegerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Si no hay otro gameManeger, marca este como persistente
        gameManegerInstance = gameObject;
        DontDestroyOnLoad(gameObject);
       
        //sceneLoaded para suscribirme a los eventos de carga de escena (se llama a la funcion PrepararJuego)
        SceneManager.sceneLoaded += PrepararJuego;
        PrepararJuego();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time = time.AddMilliseconds(Time.deltaTime * 120 * 1000);
    }

    public void PrepararJuego()
    {
        //recuperamos el gameObject player
        GameObject playerGameObject = GameObject.FindGameObjectWithTag("Player");
        if (playerGameObject != null)
        {
            DontDestroyOnLoad(playerGameObject);
        }

        //recuperamos la interfaz 
        GameObject interfazGameObject = GameObject.FindGameObjectWithTag("interfaz");
        if (interfazGameObject != null)
        {
            DontDestroyOnLoad(interfazGameObject);
        }
    }


    public void PrepararJuego(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (scene.name == "SceneGranja")
        {
            PrepararJuego();
        }
    }

    public void Jugar()
    {
        DestroyGame();
        Time.timeScale = 1.0f;

        //cargar escena
        // Usar SceneManager.sceneLoaded para esperar a que la escena esté lista
        SceneManager.LoadScene("SceneGranja");

    }

    public void Creditos()
    {
        DestroyGame();
        //cargar escena
        SceneManager.LoadScene("SceneCreditos");
    }

    public void Menu()
    {
        DestroyGame();
        //cargar escena
        SceneManager.LoadScene("SceneMenuPrincipal");
    }

    public void Salir()
    {
        //cargar escena
        Application.Quit();
    }

    public void DestroyGame()
    {
        time = new DateTime(1993, 1, 2, 7, 0, 0);
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(GameObject.FindWithTag("interfaz"));
    }

}
