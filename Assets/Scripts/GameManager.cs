using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameObject gameManegerInstance;
    public DateTime time = new DateTime(1993, 1, 2, 7, 0,0);

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
}
