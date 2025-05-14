using UnityEngine;

[CreateAssetMenu(fileName = "Nekofresa", menuName = "Scriptable Objects/Nekofresa")]
public class Nekofresa : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        Debug.Log("se usó una Nekofresa");
    }
}
