using UnityEngine;

[CreateAssetMenu(fileName = "SemillasNyantomato", menuName = "Scriptable Objects/SemillasNyantomato")]
public class SemillasNyantomato : Item
{
    Planta plantaData;

    public override void Use(PilaDeItem pilaDeItem)
    {
        ManagerDialogos.GetInstance().MostrarMensaje("Con estas semillas se podria plantar algo");

        if (plantaData == null)
        {
            plantaData = Resources.Load<Planta>("Plantas/PlantaNyantomato");
        }

        //Ponemos el juego en modoPlantar
        GameManager.GetInstance().SetIsPlanting(
            //Plantar
            plantingSpot =>
            {
                if (plantingSpot.SetPlanta(plantaData))
                {
                    pilaDeItem.cantidad--;
                    InventarioManager.GetInstance().RebuildUiInventario();
                }
            } );

    }

}
