using UnityEngine;

public class vacaMu : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //para hover
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    public Color hoverColor = Color.yellow; // Color al hacer hover
    public Vector2 hoverScale = new Vector2(1.1f, 1.1f);

    void OnMouseEnter()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;
        spriteRenderer.color = hoverColor;
        transform.localScale = hoverScale;
    }

    void OnMouseExit()
    {
        spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        spriteRenderer.color = originalColor;
        transform.localScale = Vector3.one; // Escala normal (1, 1, 1)
    }
}
