using UnityEngine;

[CreateAssetMenu(fileName = "Nekofresa", menuName = "Scriptable Objects/ekofresa")]
public class Nekofresa : Item
{
    public override void Use()
    {
        Debug.Log("se usó una Nekofresa");
    }
}
