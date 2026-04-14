using UnityEngine;
using UnityEngine.InputSystem;

public class EsferaPlayer2 : EsferaPlayerBase
{
    void FixedUpdate()
    {
        if (Keyboard.current == null) return;

        float x = 0f;
        float z = 0f;

        if (Keyboard.current.aKey.isPressed) x = -1f;
        if (Keyboard.current.dKey.isPressed) x = 1f;
        if (Keyboard.current.wKey.isPressed) z = 1f;
        if (Keyboard.current.sKey.isPressed) z = -1f;

        Vector3 dir = new Vector3(x, 0f, z).normalized;

        rb.linearVelocity = new Vector3(
            dir.x * velocidad,
            rb.linearVelocity.y,
            dir.z * velocidad
        );
    }

}