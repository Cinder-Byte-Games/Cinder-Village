using UnityEngine;

public class Interactor : MonoBehaviour
{
    // Optional override; if left null, we'll use the topmost parent (the Player)
    [SerializeField]
    private GameObject player;

    private Interactable currentInteractable;

    private void Awake()
    {
        // If no player assigned, try to use the topmost parent (the Player); otherwise leave null.
        player = transform.root != null ? transform.root.gameObject : null;

        if (player == null)
        {
            Debug.LogError(
                "Interactor could not find a player GameObject (assign it in the Inspector).",
                this
            );
            enabled = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        var interactable = other.GetComponentInParent<Interactable>();
        if (interactable == null || player == null)
            return;

        currentInteractable = interactable;
        interactable.OnPlayerEnterRange(player);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        var interactable = other.GetComponentInParent<Interactable>();
        if (interactable == null || player == null)
            return;

        if (currentInteractable == interactable)
        {
            interactable.OnPlayerExitRange(player);
            currentInteractable = null;
        }
    }
}
