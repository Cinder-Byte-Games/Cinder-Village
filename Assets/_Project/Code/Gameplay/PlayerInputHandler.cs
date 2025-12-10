using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Property holding the current movement input (x,y). Public to read, private to set.
    public Vector2 MoveInput { get; private set; }

    // Called by Unity’s Input System when the Move action updates.
    public void OnMove(InputAction.CallbackContext context)
    {
        // Read the current 2D input value (e.g., WASD/left stick) and store it.
        MoveInput = context.ReadValue<Vector2>();
    }
}
