using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Optional: a short label you can later show in UI (or ignore for now).
    [SerializeField]
    private string promptText = "Interact";

    public string PromptText => promptText;

    // Called by the player when they enter/exit range (we'll implement the player side next).
    public virtual void OnPlayerEnterRange(GameObject player)
    {
        // No UI yet; keep it simple.
        Debug.Log($"{player.name} entered range of {name} (Prompt: {promptText})");
    }

    public virtual void OnPlayerExitRange(GameObject player)
    {
        Debug.Log($"{player.name} exited range of {name}");
    }

    // What happens when the player presses Interact while targeting this object.
    public abstract void Interact(GameObject player);
}
