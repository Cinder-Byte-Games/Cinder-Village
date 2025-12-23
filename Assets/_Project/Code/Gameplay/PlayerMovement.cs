using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // SerializeField lets you edit this private field in the Inspector.
    // moveSpeed controls how fast the player moves.
    [SerializeField]
    private float moveSpeed = 5f;

    // Cached references to components assigned in the Inspector.
    [SerializeField]
    private Rigidbody2D rb;

    [SerializeField]
    private PlayerInputHandler input;

    private void Awake()
    {
        // Validate that required components are assigned.
        if (rb == null)
        {
            Debug.LogError(
                "PlayerMovement requires a Rigidbody2D component assigned in the Inspector!",
                this
            );
            enabled = false;
            return;
        }

        if (input == null)
        {
            Debug.LogError(
                "PlayerMovement requires a PlayerInputHandler assigned in the Inspector!",
                this
            );
            enabled = false;
            return;
        }
    }

    // FixedUpdate runs at a fixed timestep, ideal for physics interactions.
    private void FixedUpdate()
    {
        // Read the movement input from the inputhandler
        Vector2 move = input.MoveInput;

        // Apply the velocity: direction (move) times speed.
        // linearVelocity sets the Rigidbody2D's movement directly.
        rb.linearVelocity = move * moveSpeed;
    }
}
