using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    [SerializeField] private GameObject dialogueUI;
    [SerializeField] private Animator animator;

    private void Start()
    {
        dialogueUI.SetActive(false);
    }

    // These are *called* by the forwarder script
    public void ShowDialogue()
    {
        dialogueUI.SetActive(true);
        animator?.SetTrigger("Wave");
    }

    public void HideDialogue()
    {
        dialogueUI.SetActive(false);
    }
}

