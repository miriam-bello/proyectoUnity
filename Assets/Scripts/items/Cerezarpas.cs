using UnityEngine;

[CreateAssetMenu(fileName = "Cerezarpas", menuName = "Scriptable Objects/Cerezarpas")]
public class Cerezarpas : Item
{
    public override void Use()
    {
        Debug.Log("se usó una Cerezarpas");
    }
}
