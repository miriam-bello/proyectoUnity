using UnityEngine;

[CreateAssetMenu(fileName = "SemillasNyantomato", menuName = "Scriptable Objects/SemillasNyantomato")]
public class SemillasNyantomato : Item
{
    public override void Use()
    {
        Debug.Log("se usó una SemillasNyantomato");
    }
}
