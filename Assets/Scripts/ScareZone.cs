using UnityEngine;

public class ScareZone : MonoBehaviour
{
    [SerializeField] private SmartCompanionNPC npc;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) npc.SetAfraid();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) npc.ReturnToFollow();
    }
}
