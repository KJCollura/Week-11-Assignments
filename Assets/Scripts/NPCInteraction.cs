using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private Animator animator;

    public void ShowDialogue()
    {
        dialogueUI.SetActive(true);
        animator?.SetTrigger("Wave"); // ✅ Always wave on re-entry
    }

    public void HideDialogue()
    {
        dialogueUI.SetActive(false);
    }
}
