using UnityEngine;

[CreateAssetMenu(fileName = "Purrrengena", menuName = "Scriptable Objects/Purrrengena")]
public class Purrrengena : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        Debug.Log("se usó una Purrrengena");
    }
}
