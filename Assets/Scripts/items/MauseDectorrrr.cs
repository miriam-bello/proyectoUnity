using UnityEngine;
using UnityEngine.EventSystems;

public class MauseDectorrrr : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] string mensaje;

  

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("MouseDown: " + mensaje);
    }
}
