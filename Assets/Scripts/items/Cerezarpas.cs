using UnityEngine;

[CreateAssetMenu(fileName = "Cerezarpas", menuName = "Scriptable Objects/Cerezarpas")]
public class Cerezarpas : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        Debug.Log("se us� una Cerezarpas");
        //llamar algo que quite uno del inventario
    }
}
