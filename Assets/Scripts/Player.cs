using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private static GameObject playerInstance;
    public float velocidad = 5f;
    private new Rigidbody2D rigidbody2D;
    private Vector2 movimientoInput;
    private Animator animator;

    //para que el solo haya un objeto player
    private void Awake()
    {
        // Si ya hay un jugador, destruye este objeto para evitar duplicados
        if (playerInstance != null)
        {
            Destroy(gameObject);
            return;
        }

        // Si no hay otro jugador, marca este como singleton
        playerInstance = gameObject;
    }

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        movimientoInput.x = Input.GetAxisRaw("Horizontal");
        movimientoInput.y = Input.GetAxisRaw("Vertical");

        if (movimientoInput.x != 0 || movimientoInput.y !=0)
        {
            animator.SetFloat("Horizontal", movimientoInput.x);
            animator.SetFloat("Vertical", movimientoInput.y);
        }

        animator.SetFloat("Speed", movimientoInput.normalized.magnitude);


    }

    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = movimientoInput.normalized * velocidad;
    }

    //para recogerr del suelo
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Drop drop= collision.gameObject.GetComponentInParent<Drop>();

        if (drop)
        {
            InventarioManager inventarioManager = GameObject.FindWithTag("Inventario").GetComponent<InventarioManager>();
            inventarioManager.addItem(collision.gameObject.GetComponent<Drop>().item,1);
            Destroy(collision.gameObject);

        }
    }

}
