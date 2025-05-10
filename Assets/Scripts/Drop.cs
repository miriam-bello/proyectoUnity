using UnityEngine;

public class Drop : MonoBehaviour
{
    [SerializeField]
    public PilaDeItem pilaDeItem;

    private void Awake()
    {
        SpriteRenderer spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        Sprite spriteItem = pilaDeItem.item.icon;
        spriteRenderer.sprite = spriteItem;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}

