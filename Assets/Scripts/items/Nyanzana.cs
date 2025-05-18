using UnityEngine;

[CreateAssetMenu(fileName = "Nyanzana", menuName = "Scriptable Objects/Nyanzana")]
public class Nyanzana : Item
{

    public override void Use(PilaDeItem pilaDeItem)
    {
        ManagerDialogos.GetInstance().MostrarMensaje("Parece que a la vaca le gustaría esta fruta");
    }
}
