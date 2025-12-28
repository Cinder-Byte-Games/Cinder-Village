using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField]
    private GameObject player;

    [SerializeField]
    // How far in front of the player (along the current facing direction) the box sits,
    // measured as a distance from the player's position.
    private float interactionDistance = 0.65f;

    private Interactable currentInteractable; // Tracks which object is currently in range
    private BoxCollider2D interactionBox; // The trigger collider on this GameObject
    private PlayerInputHandler inputHandler; // Reference to get player's facing direction which is in the input handler script

    private Vector2 lastFacing;

    private void Awake()
    {
        //error checks for critical objects
        if (player == null)
        {
            Debug.LogError(
                "Interactor requires a player GameObject assigned in the Inspector.",
                this
            );
            enabled = false;
            return;
        }

        interactionBox = GetComponent<BoxCollider2D>();
        if (interactionBox == null)
        {
            Debug.LogError("Interactor requires a BoxCollider2D component!", this);
            enabled = false;
            return;
        }

        inputHandler = player.GetComponent<PlayerInputHandler>();
        if (inputHandler == null)
        {
            Debug.LogError("Interactor requires PlayerInputHandler on the player!", this);
            enabled = false;
            return;
        }

        //set if not set in unity
        interactionBox.isTrigger = true;

        // Initialize lastFacing to match the starting direction
        lastFacing = inputHandler.FacingDirection;
    }

    private void Update()
    {
        // Get the current facing direction from the input handler (up/down/left/right)
        Vector2 facing = inputHandler.FacingDirection;

        if (facing != lastFacing) // Only do resize operation if there was a change
        {
            // Move this GameObject's local position in front of the player
            // If facing right (1,0), position = (1,0) * 0.65 = (0.65, 0)
            // If facing up (0,1), position = (0,1) * 0.65 = (0, 0.65)
            // Local position is pos relative to parent
            transform.localPosition = facing * interactionDistance;

            // Facing directions for reference:
            // right -> (1, 0)
            // left -> (-1, 0)
            // up -> (0, 1)
            // down -> (0, -1)

            // Adjust the box size based on direction:
            // Player facing LEFT or RIGHT: abs(x) = 1, abs(y) = 0, so x > y is true
            //   Make box narrow horizontally (0.25), tall vertically (1)
            // Player facing UP or DOWN: abs(x) = 0, abs(y) = 1, so x > y is false
            //   Make box wide horizontally (1), narrow vertically (0.25)
            interactionBox.size =
                (Mathf.Abs(facing.x) > Mathf.Abs(facing.y))
                    ? new Vector2(0.25f, 1f)
                    : new Vector2(1f, 0.25f);
        }

        lastFacing = facing;
    }

    /// <summary>
    /// Attempts to interact with the currently targeted interactable object.
    /// </summary>
    /// <remarks>
    /// If a valid interactable is within range and stored in <c>currentInteractable</c>,
    /// this method calls its Interact method and passes the player reference.
    /// If no interactable is currently targeted, a debug message is logged.
    /// </remarks>
    public void TryInteract()
    {
        // Do we have a target stored?
        if (currentInteractable != null)
        {
            // Yes: call its Interact method
            currentInteractable.Interact(player);
        }
        else
        {
            // No: nothing in range
            Debug.Log("No interactable in range.");
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object that entered has an Interactable component
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null)
            return; // Not an interactable, ignore it

        // Store it as the current target
        currentInteractable = interactable;

        // Notify it that player entered range
        interactable.OnPlayerEnterRange(player);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Interactable interactable = other.GetComponent<Interactable>();
        if (interactable == null)
            return;

        // Only clear if THIS is the object we were tracking
        if (currentInteractable == interactable)
        {
            interactable.OnPlayerExitRange(player);
            currentInteractable = null; // Clear the target
        }
    }
}
