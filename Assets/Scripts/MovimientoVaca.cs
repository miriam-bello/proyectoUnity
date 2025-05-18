using UnityEngine;

public class MovimientoVaca : MonoBehaviour
{
    public Vector3[] waypoints;  // Lista de puntos a seguir
    public float velocidad = 3f;
    private int acutalWaypoint = 0;
    public bool sePuedoMover= false;
    Animator animatorVaca;


    private void Start()
    {
        animatorVaca = GetComponent<Animator>();
    }

    void Update()
    {
        if (!sePuedoMover) {
            animatorVaca.SetFloat("speed", 0f);
            return;
        }

        // Mueve al NPC hacia el waypoint actual
        animatorVaca.transform.position = Vector3.MoveTowards(
            transform.position,
            waypoints[acutalWaypoint],
            velocidad * Time.deltaTime
        );

        animatorVaca.SetFloat("speed", velocidad);

        // Si llega al waypoint, pasa al siguiente
        if (Vector3.Distance(animatorVaca.transform.position, waypoints[acutalWaypoint]) < 0.1f)
        {
            acutalWaypoint = (acutalWaypoint + 1);

            if (acutalWaypoint >= waypoints.Length)
            {
                sePuedoMover = false;
                animatorVaca.SetFloat("speed", 0f); 
                return;
            }
        }
       
    }
}