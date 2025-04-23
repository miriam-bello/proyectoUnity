using System;
using TMPro;
using UnityEngine;

public class ActualizarFecha : MonoBehaviour
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
        DayOfWeek diaSemana = fecha.DayOfWeek;

        TMP_Text textoHora = GetComponent<TextMeshProUGUI>();
        textoHora.text = diaSemana.ToString();
    }
}
