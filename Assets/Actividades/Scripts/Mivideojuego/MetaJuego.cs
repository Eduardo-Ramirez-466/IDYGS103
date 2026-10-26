
using UnityEngine;

public class MetaJuego : MonoBehaviour
{
    private bool ganaste = false;

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player") && !ganaste)
        {
            ganaste = true;

            Debug.Log("¡GANASTE! Llegaste a la meta.");

            // Detener el movimiento del jugador
            Rigidbody2D rb = otro.GetComponent<Rigidbody2D>();

            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.simulated = false;
            }

            // Desactivar el script de movimiento
            MovimientoJugador movimiento =
                otro.GetComponent<MovimientoJugador>();

            if (movimiento != null)
            {
                movimiento.enabled = false;
            }
        }
    }

    void OnGUI()
    {
        if (ganaste)
        {
            GUIStyle estilo = new GUIStyle(GUI.skin.label);
            estilo.fontSize = 40;
            estilo.fontStyle = FontStyle.Bold;
            estilo.alignment = TextAnchor.MiddleCenter;
            estilo.normal.textColor = Color.green;

            GUI.Label(
                new Rect(0, 0, Screen.width, Screen.height),
                "¡GANASTE!",
                estilo
            );
        }
    }
}
