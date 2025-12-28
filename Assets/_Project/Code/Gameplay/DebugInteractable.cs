using UnityEngine;

public class DebugInteractable : Interactable
{
    public override void Interact(GameObject player)
    {
        Debug.Log($"{player.name} interacted with {name}!");
    }
}
