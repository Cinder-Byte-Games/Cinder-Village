using UnityEngine;

// RequireComponent tells Unity to auto-add a Rigidbody2D if missing on this GameObject.
[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    // SerializeField lets you edit this private field in the Inspector.
    // moveSpeed controls how fast the player moves.
    [SerializeField]
    private float moveSpeed = 5f;

    // Cached references to components on the same GameObject.
    private Rigidbody2D rb;
    private PlayerInputHandler input;

    private void Awake()
    {
        // Grab the Rigidbody2D component Unity ensures exists (because of RequireComponent).
        rb = GetComponent<Rigidbody2D>();
        // Grab the PlayerInputHandler to read input values.
        input = GetComponent<PlayerInputHandler>();
    }

    // FixedUpdate runs at a fixed timestep, ideal for physics interactions.
    private void FixedUpdate()
    {
        // Read the movement input if available; otherwise default to zero movement.
        Vector2 move = input != null ? input.MoveInput : Vector2.zero;

        // Apply the velocity: direction (move) times speed.
        // linearVelocity sets the Rigidbody2D's movement directly.
        rb.linearVelocity = move * moveSpeed;
    }
}
