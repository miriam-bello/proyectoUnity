using System;
using TMPro;
using UnityEngine;

public class ActualizarHora : MonoBehaviour
{


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameManager = GameObject.FindWithTag("GameManager");
        DateTime fecha = gameManager.GetComponent<GameManager>().time;
        int minutos= fecha.Minute;
        int horas = fecha.Hour;
        Debug.Log("hora " + fecha.Second);

        TMP_Text textoHora = GetComponent<TextMeshProUGUI>();
        textoHora.text= fecha.ToString("HH:mm");

    }
}
