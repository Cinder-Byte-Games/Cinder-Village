using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Property holding the current movement input (x,y). Public to read, private to set.
    public Vector2 MoveInput { get; private set; }

    // Called by Unity’s Input System when the Move action updates.
    public void OnMove(InputAction.CallbackContext context)
    {
        // Only read the value if the context is in the performed or started state.
        if (context.performed || context.started)
        {
            MoveInput = context.ReadValue<Vector2>();
        }
    }
}
