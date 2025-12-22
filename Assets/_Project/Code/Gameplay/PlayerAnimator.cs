using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private Animator animator;
    private PlayerInputHandler input;

    private void Awake()
    {
        // Animator should be on this Graphics child
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("PlayerAnimator requires an Animator component!", this);
            enabled = false;
            return;
        }

        // Input lives on the Player (parent), so search upwards
        input = GetComponentInParent<PlayerInputHandler>();
        if (input == null)
        {
            Debug.LogError(
                "PlayerAnimator could not find PlayerInputHandler on a parent object!",
                this
            );
            enabled = false;
            return;
        }
    }

    private void Update()
    {
        // Read the movement input
        Vector2 move = input.MoveInput;

        // Set current input axes for blend tree
        animator.SetFloat("InputX", move.x);
        animator.SetFloat("InputY", move.y);

        // Set walking state
        // Check against 0.01f to avoid false positives from analog stick drift or floating-point imprecision
        bool isWalking = move.sqrMagnitude > 0.01f;
        animator.SetBool("IsWalking", isWalking);

        // Update last input direction (for idle facing direction)
        if (isWalking)
        {
            animator.SetFloat("LastInputX", move.x);
            animator.SetFloat("LastInputY", move.y);
        }
    }
}
