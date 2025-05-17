using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
public class SlutScript : MonoBehaviour,IPointerClickHandler
{

    [SerializeField] int slutPosition;

    public void OnPointerClick(PointerEventData eventData)
    {
        GameObject inventario = GameObject.FindGameObjectWithTag("Inventario");
        InventarioManager inventarioManager = inventario.GetComponent<InventarioManager>();

        inventarioManager.useItemAt(slutPosition);
    }

    public void SetCantidad(int cantidad) {
        GameObject cantidadGameObject = transform.Find("Cantidad").gameObject;
        cantidadGameObject.GetComponent<TextMeshProUGUI>().SetText(cantidad.ToString());

    }


}
