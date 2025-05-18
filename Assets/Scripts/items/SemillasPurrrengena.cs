using UnityEngine;

[CreateAssetMenu(fileName = "SemillasPurrrengena", menuName = "Scriptable Objects/SemillasPurrrengena")]
public class SemillasPurrrengena : Item
{
    Planta plantaData;

    public override void Use(PilaDeItem pilaDeItem)
    {
        ManagerDialogos.GetInstance().MostrarMensaje("Con estas semillas se podria plantar algo");

        if (plantaData == null)
        {
            plantaData = Resources.Load<Planta>("Plantas/PlantaPurrrengena");
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
                }

            );
    }



}
