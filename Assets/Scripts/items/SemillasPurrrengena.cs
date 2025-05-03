using UnityEngine;

[CreateAssetMenu(fileName = "SemillasPurrrengena", menuName = "Scriptable Objects/SemillasPurrrengena")]
public class SemillasPurrrengena : Item
{
    public override void Use()
    {
        Debug.Log("se usó una SemillasPurrrengena");
    }
}
