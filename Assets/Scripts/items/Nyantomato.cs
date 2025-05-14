using UnityEngine;

[CreateAssetMenu(fileName = "Nyantomato", menuName = "Scriptable Objects/Nyantomato")]
public class Nyantomato : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        Debug.Log("se usó una Nyantomato");
    }
}
