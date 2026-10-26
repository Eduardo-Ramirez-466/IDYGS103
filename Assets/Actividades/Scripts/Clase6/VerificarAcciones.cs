using UnityEngine;
using UnityEngine.InputSystem;

// Ejercicio 1: comprueba que las acciones Move, Jump y ChangeColor de PlayerControls funcionan.
public class VerificarAcciones : MonoBehaviour
{
    private Vector2 move;
    private string ultimaAccion = "(presiona W/A/S/D, Espacio o C)";
    private GUIStyle estilo;

    public void OnMove(InputValue value)
    {
        move = value.Get<Vector2>();
    }

    public void OnJump(InputValue value)
    {
        if (!value.isPressed) return;
        ultimaAccion = "Jump (Espacio)";
        Debug.Log("Jump");
    }

    public void OnChangeColor(InputValue value)
    {
        if (!value.isPressed) return;
        ultimaAccion = "ChangeColor (C)";
        Debug.Log("ChangeColor");
    }

    void OnGUI()
    {
        if (estilo == null)
        {
            estilo = new GUIStyle(GUI.skin.label) { fontSize = 26, fontStyle = FontStyle.Bold };
            estilo.normal.textColor = Color.white;
        }
        GUI.Label(new Rect(15, 10, 900, 40), "Move: " + move, estilo);
        GUI.Label(new Rect(15, 50, 900, 40), "Ultima accion: " + ultimaAccion, estilo);
    }
}
