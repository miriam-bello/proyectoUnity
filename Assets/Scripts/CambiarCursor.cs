using UnityEngine;

public class CambiarCursor : MonoBehaviour
{
    public Texture2D cursorTexture; // Asigna tu textura del cursor en el Inspector
    public Vector2 hotSpot = Vector2.zero; // Punto activo del cursor (generalmente donde hace "click")
    public CursorMode cursorMode = CursorMode.Auto;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    void Start()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
