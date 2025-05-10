using UnityEngine;

[RequireComponent(typeof(Collider2D))] // Fuerza a tener Collider2D

public class InteractuarPc : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;

    private void OnMouseDown()
    {
        tutorial.GetComponent<Canvas>().enabled = true;
        Debug.Log("usando el ordenador", this);

    }

    
}
