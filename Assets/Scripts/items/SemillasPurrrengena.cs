using UnityEngine;

[CreateAssetMenu(fileName = "SemillasPurrrengena", menuName = "Scriptable Objects/SemillasPurrrengena")]
public class SemillasPurrrengena : Item
{


    Planta plantaData;

    public override void Use()
    {
        if (plantaData == null)
        {
            plantaData = Resources.Load<Planta>("Plantas/PlantaPurrrengena");
        }

        GameManager.GetInstance().SetIsPlanting(
            plantingSpot => plantingSpot.SetPlanta(plantaData)
            );
        Debug.Log("se usó una SemillasPurrrengena");

    }

}
