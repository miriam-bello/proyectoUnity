using System;
using UnityEngine;

public class PlantingSpotScript : MonoBehaviour
{
    //momento en el que fue plantado
    private DateTime plantadoTime;
    private Planta plantaPlantada;

    public void SetPlanta(Planta planta)
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        BoxCollider2D boxCollider = gameObject.GetComponent<BoxCollider2D>();
        plantaPlantada = planta;
        spriteRenderer.enabled = false;
        boxCollider.isTrigger = true;
        if (planta != null)
        {
            boxCollider.isTrigger = false;
            spriteRenderer.enabled = true;
            plantadoTime = GameManager.GetInstance().time;
            spriteRenderer.sprite = planta.plantado;
        }

    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
