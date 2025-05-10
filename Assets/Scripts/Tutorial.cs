using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject tutorial;
    public void cerrarTuto()
    {
        tutorial.GetComponent<Canvas>().enabled = false;
    }

}
