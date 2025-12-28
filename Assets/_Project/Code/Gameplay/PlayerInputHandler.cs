using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    // Property holding the current movement input (x,y). Public to read, private to set.
    public Vector2 MoveInput { get; private set; }

    // Track the last non-zero facing direction (defaults to down) and persist it when movement stops
    public Vector2 FacingDirection { get; private set; } = Vector2.down;

    // Called by Unity’s Input System when the Move action updates.
    public void OnMove(InputAction.CallbackContext context)
    {
        // Only read the value if the context is in the performed or started state.
        if (context.performed || context.started)
        {
            MoveInput = context.ReadValue<Vector2>();

            // Update facing direction when moving
            if (MoveInput.sqrMagnitude > 0.01f)
            {
                // Snap to 4 cardinal directions
                if (Mathf.Abs(MoveInput.x) > Mathf.Abs(MoveInput.y))
                {
                    FacingDirection = MoveInput.x > 0 ? Vector2.right : Vector2.left;
                }
                else
                {
                    FacingDirection = MoveInput.y > 0 ? Vector2.up : Vector2.down;
                }
            }
        }
        else if (context.canceled)
        {
            MoveInput = Vector2.zero;
        }
    }

    public void OnInteract(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            var interactor = GetComponentInChildren<Interactor>();
            if (interactor != null)
            {
                interactor.TryInteract();
            }
        }
    }
}
