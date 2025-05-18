using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private static GameObject gameManegerInstance;
    public DateTime time = new DateTime(1993, 1, 2, 7, 0, 0);

  
    //--------------- instancia del gameManager ---------------
    public static GameManager GetInstance()
    {
        return GameObject.FindWithTag("GameManager").GetComponent<GameManager>();
    }


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

    // Update is called once per frame
    void Update()
    {
        time = time.AddMilliseconds(Time.deltaTime * 120 * 1000);
        HandlePlanting();
    }

    //---------------Preparar juego----------------
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
            ShowPlantingSpots();
        } else {
            HidePlantingSpots();
        }
    }

    //----------------Gesti�n de las pantallas ---------------
    public void Jugar()
    {
        DestroyGame();
        Time.timeScale = 1.0f;

        //cargar escena
        // Usar SceneManager.sceneLoaded para esperar a que la escena est� lista
        Granja();

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

    public void Final()
    {
        //cargar escena
        DestroyGame();
        SceneManager.LoadScene("SceneFinal");
    }

    public void Salir()
    {
        //cargar escena
        Application.Quit();
    }

    public void HidePlantingSpots()
    {
        GameObject plantingSpots = GameObject.FindGameObjectWithTag("PlantingSpots");
        if (plantingSpots == null) {
            return;
        }
        Vector3 nuevaPosicion = new Vector3(plantingSpots.transform.position.x, plantingSpots.transform.position.y, -11);
        plantingSpots.transform.SetPositionAndRotation(nuevaPosicion, plantingSpots.transform.rotation);
    }

    public void ShowPlantingSpots()
    {
        GameObject plantingSpots = GameObject.FindGameObjectWithTag("PlantingSpots");
        Vector3 nuevaPosicion = new Vector3(plantingSpots.transform.position.x, plantingSpots.transform.position.y, 0);
        plantingSpots.transform.SetPositionAndRotation(nuevaPosicion, plantingSpots.transform.rotation);
    }

    public void Granja()
    {
        SceneManager.LoadScene("SceneGranja");
    }

    public void Casa()
    {
        SceneManager.LoadScene("SceneCasa");
    }


    //---------------destruir objetos---------------
    public void DestroyGame()
    {
        time = new DateTime(1993, 1, 2, 7, 0, 0);
        Destroy(GameObject.FindWithTag("Player"));
        Destroy(GameObject.FindWithTag("interfaz"));
        Destroy(GameObject.FindWithTag("Inventario"));
    }

    //-----------Gesti�n plantar----------

    Action<PlantingSpotScript> onPlant;
    bool isPlanting = false;
    public LayerMask plantingLayer;

    //le pasamos una lambda, recibe un PlantingSpotScript
    public void SetIsPlanting(Action<PlantingSpotScript> onPlant)
    {
        isPlanting = onPlant != null;

        if (isPlanting)
        {
            Debug.Log("Entering planting mode");
        }
        else {
            Debug.Log("Leaving planting mode");
        }
         
        this.onPlant = onPlant;
    }

    private void HandlePlanting()
    {
        if (!isPlanting)
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (EventSystem.current.IsPointerOverGameObject()) {
                Debug.Log("Yes");
            }

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit2D[] hits = Physics2D.RaycastAll(new Vector2(ray.origin.x, ray.origin.y), Vector2.zero, plantingLayer);
            foreach (RaycastHit2D raycastHit in hits)
            {
                PlantingSpotScript plantingSpot = raycastHit.collider.gameObject.GetComponent<PlantingSpotScript>();
                onPlant(plantingSpot);
                SetIsPlanting(null);
                break;
            }

        }
        else
        {
            // TODO Marcar los planting spots
        }
    }
}
