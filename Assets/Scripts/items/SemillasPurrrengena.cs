using UnityEngine;

[CreateAssetMenu(fileName = "SemillasPurrrengena", menuName = "Scriptable Objects/SemillasPurrrengena")]
public class SemillasPurrrengena : Item
{
    Planta plantaData;

    public override void Use(PilaDeItem pilaDeItem)
    {
        if (plantaData == null)
        {
            plantaData = Resources.Load<Planta>("Plantas/PlantaPurrrengena");
        }

        GameManager.GetInstance().SetIsPlanting(
            plantingSpot =>
                {
                    plantingSpot.SetPlanta(plantaData);
                    pilaDeItem.cantidad--;
                    InventarioManager.GetInstance().RebuildUiInventario();
                }

            );
        Debug.Log("se usó una SemillasPurrrengena");

    }



}
