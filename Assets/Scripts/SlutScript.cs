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


}
