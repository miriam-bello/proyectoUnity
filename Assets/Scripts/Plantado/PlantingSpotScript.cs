using System;
using UnityEngine;

public class PlantingSpotScript : MonoBehaviour
{
    private static GameObject plantingSpotInstance;
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

}
