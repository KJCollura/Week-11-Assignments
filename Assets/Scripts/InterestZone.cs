using UnityEngine;

public class InterestZone : MonoBehaviour
{
    [SerializeField] private SmartCompanionNPC npc;
    [SerializeField] private float idleTime = 3f;

    private float idleTimer;
    private bool playerInside;

    private void Update()
    {
        if (playerInside)
        {
            idleTimer += Time.deltaTime;
            if (idleTimer >= idleTime)
            {
                npc.SetCurious();
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = true;
            idleTimer = 0f;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInside = false;
            idleTimer = 0f;
            npc.ReturnToFollow();
        }
    }
}
