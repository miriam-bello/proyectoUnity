using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Fuerza a tener Collider2D

public class interactuarObjetos : MonoBehaviour
{
    private void OnMouseDown()
    {
        Debug.Log("FUNCIONA!", this); // Mostrará el objeto en la consola al hacer clic
    }

}
