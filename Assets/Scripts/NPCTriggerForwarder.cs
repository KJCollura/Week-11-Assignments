using UnityEngine;

public class NPCTriggerForwarder : MonoBehaviour
{
    [SerializeField] private NPCInteraction npcInteraction;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        npcInteraction.ShowDialogue();
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        npcInteraction.HideDialogue();
    }
}

