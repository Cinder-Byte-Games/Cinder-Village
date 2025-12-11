using UnityEngine;

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
        // Grab the Rigidbody2D component. The null check below ensures it exists.
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("PlayerMovement requires a Rigidbody2D component!", this);
            enabled = false;
            return;
        }

        // Grab the PlayerInputHandler to read input values.
        input = GetComponent<PlayerInputHandler>();
        if (input == null)
        {
            Debug.LogError("PlayerMovement requires a PlayerInputHandler component!", this);
            enabled = false;
            return;
        }
    }

    // FixedUpdate runs at a fixed timestep, ideal for physics interactions.
    private void FixedUpdate()
    {
        // Read the movement input
        Vector2 move = input.MoveInput;

        // Apply the velocity: direction (move) times speed.
        // linearVelocity sets the Rigidbody2D's movement directly.
        rb.linearVelocity = move * moveSpeed;
    }
}
