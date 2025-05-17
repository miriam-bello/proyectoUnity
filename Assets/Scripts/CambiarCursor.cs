using UnityEngine;

public class CambiarCursor : MonoBehaviour
{
    public Texture2D cursorNormal;
    public Texture2D cursorHover;
    public Vector2 hotSpot = Vector2.zero;
    public CursorMode cursorMode = CursorMode.Auto;
    
    void Start()
    {
        Cursor.SetCursor(cursorNormal, hotSpot, cursorMode);
    }

    private void Update()
    {
      

      
    }
}
