using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    // Serialized text shown in UI when player is in range (editable in Inspector).
    [SerializeField]
    private string promptText = "Interact";

    // Reference to the Canvas GameObject that holds the prompt UI
    [SerializeField]
    private Canvas promptCanvas;

    /// <summary>
    /// Public read-only property that exposes the prompt text.
    /// </summary>
    public string PromptText => promptText;

    /// <summary>
    /// Called when the player enters this object's trigger range.
    /// Virtual so derived classes can override with custom behavior.
    /// </summary>
    public virtual void OnPlayerEnterRange(GameObject player)
    {
        // Show the prompt UI
        if (promptCanvas != null)
        {
            promptCanvas.gameObject.SetActive(true);
        }
        Debug.Log($"{player.name} entered range of {name} (Prompt: {promptText})");
    }

    /// <summary>
    /// Called when the player exits this object's trigger range.
    /// Virtual so derived classes can override with custom behavior.
    /// </summary>
    public virtual void OnPlayerExitRange(GameObject player)
    {
        // Hide the prompt UI
        if (promptCanvas != null)
        {
            promptCanvas.gameObject.SetActive(false);
        }
        Debug.Log($"{player.name} exited range of {name}");
    }

    /// <summary>
    /// Called when the player presses the Interact input while targeting this object.
    /// Abstract—every derived class must implement this with its own interaction logic.
    /// </summary>
    public abstract void Interact(GameObject player);
}
