using UnityEngine;

[CreateAssetMenu(fileName = "SemillasNyantomato", menuName = "Scriptable Objects/SemillasNyantomato")]
public class SemillasNyantomato : Item
{
    Planta plantaData;

    public override void Use(PilaDeItem pilaDeItem)
    {

        if (plantaData == null)
        {
            plantaData = Resources.Load<Planta>("Plantas/PlantaNyantomato");
        }

        GameManager.GetInstance().SetIsPlanting(
            plantingSpot =>
            {
                plantingSpot.SetPlanta(plantaData);
                pilaDeItem.cantidad--;
                InventarioManager.GetInstance().RebuildUiInventario();
            }

            );


        Debug.Log("se usó una SemillasNyantomato");
    }
}
