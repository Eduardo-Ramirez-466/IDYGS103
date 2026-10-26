using UnityEngine;
using UnityEngine.InputSystem;

public class PropulsorController : MonoBehaviour
{
    [SerializeField] float thrust = 20f;

    Rigidbody2D shipBody;

    void Awake()
    {
        shipBody = GetComponentInParent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        var keyboard = Keyboard.current;
        if (keyboard == null) return;

        var direction = Vector2.zero;
        if (keyboard.wKey.isPressed) direction.y += 1f;
        if (keyboard.sKey.isPressed) direction.y -= 1f;
        if (keyboard.dKey.isPressed) direction.x += 1f;
        if (keyboard.aKey.isPressed) direction.x -= 1f;

        shipBody.AddForce(direction * thrust);
    }
}
