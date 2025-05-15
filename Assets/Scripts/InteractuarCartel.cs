using UnityEngine;

public class InteractuarCartel : MonoBehaviour
{
    [SerializeField] private GameObject cartel;

    private void OnMouseDown()
    {
        cartel.GetComponent<Canvas>().enabled = true;
        Debug.Log("viendo cartel", this);

    }
}
