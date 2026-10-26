
using UnityEngine;

public class MovimientoJugador : MonoBehaviour
{
    [Header("Configuracion del jugador")]
    public float velocidad = 5f;
    public float fuerzaSalto = 12f;

    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;

    private bool enSuelo = false;
    private float movimiento;

    // Guarda la posicion inicial del jugador
    private Vector3 posicionInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        // Guardar la posicion inicial del circulo
        posicionInicial = transform.position;
    }

    void Update()
    {
        // Movimiento horizontal con A y D
        movimiento = Input.GetAxisRaw("Horizontal");

        // Saltar con espacio
        if (Input.GetKeyDown(KeyCode.Space) && enSuelo)
        {
            rb.linearVelocity = new Vector2(
                rb.linearVelocity.x, 0f
            );

            rb.AddForce(
                Vector2.up * fuerzaSalto,
                ForceMode2D.Impulse
            );

            // Cambiar a un color aleatorio
            spriteRenderer.color = new Color(
                Random.Range(0.2f, 1f),
                Random.Range(0.2f, 1f),
                Random.Range(0.2f, 1f)
            );

            enSuelo = false;
        }

        // Reiniciar si cae fuera del escenario
        if (transform.position.y < -10f)
        {
            ReiniciarJugador();
        }
    }

    void FixedUpdate()
    {
        // Controlar la velocidad horizontal
        rb.linearVelocity = new Vector2(
            movimiento * velocidad,
            rb.linearVelocity.y
        );
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        VerificarSuelo(collision);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        VerificarSuelo(collision);
    }

    void VerificarSuelo(Collision2D collision)
    {
        foreach (ContactPoint2D contacto in collision.contacts)
        {
            if (contacto.normal.y > 0.5f)
            {
                enSuelo = true;
                return;
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        enSuelo = false;
    }

    // Metodo para reiniciar al jugador
    public void ReiniciarJugador()
    {
        // Regresar al punto inicial
        transform.position = posicionInicial;

        // Detener cualquier movimiento
        rb.linearVelocity = Vector2.zero;
        rb.angularVelocity = 0f;

        // Restablecer controles y salto
        movimiento = 0f;
        enSuelo = false;

        Debug.Log("Jugador reiniciado en el punto inicial");
    }
}
