
using UnityEngine;

public class Obstaculo : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D otro)
    {
        // Verificar si el objeto es el jugador
        if (otro.CompareTag("Player"))
        {
            // Obtener el script del jugador
            MovimientoJugador jugador =
                otro.GetComponent<MovimientoJugador>();

            if (jugador != null)
            {
                // Reiniciar desde el punto inicial
                jugador.ReiniciarJugador();

                Debug.Log(
                    "¡Has muerto! Regresando al inicio."
                );
            }
        }
    }
}
