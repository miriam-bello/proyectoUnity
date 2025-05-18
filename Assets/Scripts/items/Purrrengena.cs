using UnityEngine;

[CreateAssetMenu(fileName = "Purrrengena", menuName = "Scriptable Objects/Purrrengena")]
public class Purrrengena : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        ManagerDialogos.GetInstance().MostrarMensaje("Parece que a la vaca le gustaría esta fruta");
    }
}
