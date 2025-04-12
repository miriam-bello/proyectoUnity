using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public float velocidad = 5f;
    private Rigidbody2D rigidbody2D;
    private Vector2 movimientoInput;
    private Vector2 ultimaDireccion;
    private Animator animator;

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
        Debug.Log(movimientoInput);
        if (movimientoInput.x > 0.1 || movimientoInput.x < -0.1)
        {
            animator.SetFloat("Horizontal", movimientoInput.x);
            animator.SetFloat("Speed", movimientoInput.magnitude);
            
        }


        if (movimientoInput.y > 0.1 || movimientoInput.y < -0.1)
        {
            animator.SetFloat("Vertical", movimientoInput.y);
            animator.SetFloat("Speed", movimientoInput.magnitude);
        }
        

        movimientoInput = movimientoInput.normalized;


    }

    private void FixedUpdate()
    {
        rigidbody2D.linearVelocity = movimientoInput * velocidad;
    }
}
