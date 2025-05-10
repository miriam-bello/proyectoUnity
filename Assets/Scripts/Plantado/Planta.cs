using UnityEngine;
//definición de una planta
//para que lo puedas guardar como un fichero.asset
[CreateAssetMenu(fileName = "Nueva Planta", menuName = "Inventory/Plantas")]
public class Planta : ScriptableObject
{
    public Sprite plantado;
    public Sprite creciendo1;
    public Sprite creciendo2;
    public Sprite crecido; 
    public Sprite conFruto;

}
