using UnityEngine;

[CreateAssetMenu(fileName = "Nyantomato", menuName = "Scriptable Objects/Nyantomato")]
public class Nyantomato : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        ManagerDialogos.GetInstance().MostrarMensaje("Parece que a la nekovaca le gustar�a esta fruta");

    }
}
