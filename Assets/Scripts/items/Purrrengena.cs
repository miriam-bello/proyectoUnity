using UnityEngine;

[CreateAssetMenu(fileName = "Purrrengena", menuName = "Scriptable Objects/Purrrengena")]
public class Purrrengena : Item
{
    public override void Use()
    {
        Debug.Log("se us� una Purrrengena");
    }
}
