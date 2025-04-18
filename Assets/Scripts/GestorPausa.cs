using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class GestorPausa : MonoBehaviour
{
   private GameObject MenuPausa;
   private bool juegoPausado= false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {

            if (juegoPausado)
            {
                Reanudar();
            }
            else { Pausa(); }
        }
    }

    public void Pausa()
    {
        juegoPausado= true;
        Time.timeScale = 0f;
       
    }

    public void Salir() {
        SceneManager.LoadScene("SceneMenuPrincipal");
    }

    public void Reanudar() {
        juegoPausado = false;
        Time.timeScale = 1f;
        MenuPausa.SetActive(false);
    }
   
}
