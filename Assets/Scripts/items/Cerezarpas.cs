using UnityEngine;

[CreateAssetMenu(fileName = "Cerezarpas", menuName = "Scriptable Objects/Cerezarpas")]
public class Cerezarpas : Item
{
    public override void Use(PilaDeItem pilaDeItem)
    {
        ManagerDialogos.GetInstance().MostrarMensaje("Parece que a la vaca le gustaría esta fruta");
    }
}
