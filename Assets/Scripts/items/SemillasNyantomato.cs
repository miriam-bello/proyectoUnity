using UnityEngine;

[CreateAssetMenu(fileName = "SemillasNyantomato", menuName = "Scriptable Objects/SemillasNyantomato")]
public class SemillasNyantomato : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        Debug.Log("se us� una SemillasNyantomato");
    }
}
