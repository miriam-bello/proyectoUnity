using System;
using UnityEngine;

public class PlantingSpotScript : MonoBehaviour
{
    private static GameObject plantingSpotInstance;
    //momento en el que fue plantado
    public DateTime plantadoTime;
    public Planta plantaPlantada;


    public bool SetPlanta(Planta planta)
    {
        if (this.plantaPlantada != null)
        {
            return false;
        }
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

        return true;

    }

    public void Update()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (plantaPlantada == null) { return; }

        //si ha pasado mas de x tiempo desde que se plant� cambiar el estado de la planta
        DateTime horaDeCrecer1 = plantadoTime.AddMinutes(plantaPlantada.minutosCreciendo1);
        DateTime horaDeCrecer2 = plantadoTime.AddMinutes(plantaPlantada.minutosCreciendo2);
        DateTime horaDeCrecer3 = plantadoTime.AddMinutes(plantaPlantada.minutosCrecido);
        DateTime horaDeFruto4 = plantadoTime.AddMinutes(plantaPlantada.minutosConFruto);

        //crecer

        if (GameManager.GetInstance().time > horaDeFruto4)
        {
            spriteRenderer.sprite = plantaPlantada.conFruto;
            return;
        }

        if (GameManager.GetInstance().time > horaDeCrecer3)
        {
            spriteRenderer.sprite = plantaPlantada.crecido;
            return;
        }


        if (GameManager.GetInstance().time > horaDeCrecer2)
        {
            spriteRenderer.sprite = plantaPlantada.creciendo2;
            return;
        }

        if (GameManager.GetInstance().time > horaDeCrecer1)
        {
            spriteRenderer.sprite = plantaPlantada.creciendo1;
        }

    }

    private bool isConFruto()
    {
        if (plantaPlantada == null)
        {
            return false;
        }

        return gameObject.GetComponent<SpriteRenderer>().sprite == plantaPlantada.conFruto;
    }

    [SerializeField] private float distanciaInteraccion = 3f; // Rango
    private Transform jugador;

    private void Start()
    {
        //buscamos la posicion del jugador
        jugador = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }
    private void OnMouseDown()
    {
        //calcula la distancia
        float distancia = Vector2.Distance(
            new Vector2(transform.position.x, transform.position.y),
            new Vector2(jugador.position.x, jugador.position.y)
        );

        //activa el cartel cual haces click si la distancia es menor o igual al Rango(3f)
        if (distancia <= distanciaInteraccion)
        {

            if (isConFruto())
            {

                //semillas aleatorias
                int numeroAleatorio = UnityEngine.Random.Range(0, 3);

                if (numeroAleatorio < 1)
                {
                    numeroAleatorio = UnityEngine.Random.Range(0, 1);
                    if (numeroAleatorio > 0)
                    {
                        InventarioManager.GetInstance().addItem(Resources.Load<SemillasPurrrengena>("Items/SemillasPurrrengena"), 1);
                    }
                    InventarioManager.GetInstance().addItem(Resources.Load<SemillasNyantomato>("Items/SemillasNyantomato"), 1);

                }

                InventarioManager.GetInstance().addItem(plantaPlantada.fruto, 3);
                this.plantadoTime = GameManager.GetInstance().time.AddMinutes(-plantaPlantada.minutosCreciendo2);
            }
        }
    }

}
