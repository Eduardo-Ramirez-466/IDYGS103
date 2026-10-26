using UnityEngine;
using UnityEngine.InputSystem;

// Propulsor de la nave: cambia de color mientras se presionan las teclas de empuje (WASD).
public class PropulsorColor : MonoBehaviour
{
    [SerializeField] Color colorEncendido = new Color(1f, 0.55f, 0f);
    [SerializeField] Color colorApagado = Color.white;

    SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        var k = Keyboard.current;
        if (k == null) return;

        bool empujando = k.wKey.isPressed || k.aKey.isPressed || k.sKey.isPressed || k.dKey.isPressed || k.cKey.isPressed;
        sr.color = empujando ? colorEncendido : colorApagado;
    }
}
