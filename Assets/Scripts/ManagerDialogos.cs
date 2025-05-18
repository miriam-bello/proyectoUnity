using TMPro;
using UnityEditor.Timeline.Actions;
using UnityEngine;

public class ManagerDialogos : MonoBehaviour
{

    private static GameObject instance;
    public static ManagerDialogos GetInstance()
    {
        return instance.GetComponent<ManagerDialogos>();
    }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = gameObject;

    }

    public void MostrarMensaje(string mensaje)
    {
        gameObject.GetComponent<Canvas>().enabled = true;
        gameObject.transform.Find("Text").GetComponent<TextMeshProUGUI>().text = mensaje;
        Invoke("OcultarMensaje", 4f);
    }

    void OcultarMensaje() {
        gameObject.GetComponent<Canvas>().enabled = false;
    }


  

}
