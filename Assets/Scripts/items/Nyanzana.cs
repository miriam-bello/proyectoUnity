using UnityEngine;

[CreateAssetMenu(fileName = "Nyanzana", menuName = "Scriptable Objects/Nyanzana")]
public class Nyanzana : Item
{

    public override void Use(PilaDeItem pilaDeItem)
    {
        Debug.Log("Parece una Nyanzana muy sabrosa");
    }
}
