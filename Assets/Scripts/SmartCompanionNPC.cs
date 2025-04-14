using UnityEngine;
using UnityEngine.AI;

public enum NPCState
{
    Following,
    Fleeing,
    Investigating
}

[RequireComponent(typeof(NavMeshAgent))]
public class SmartCompanionNPC : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform hideSpot;
    [SerializeField] private Transform objectOfInterest;
    [SerializeField] private float stopDistance = 1.5f;

    private NavMeshAgent agent;
    private NPCState currentState = NPCState.Following;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.stoppingDistance = stopDistance;
    }

    private void Update()
    {
        switch (currentState)
        {
            case NPCState.Following:
                agent.SetDestination(player.position);
                break;

            case NPCState.Fleeing:
                agent.SetDestination(hideSpot.position);
                break;

            case NPCState.Investigating:
                agent.SetDestination(objectOfInterest.position);
                break;
        }
    }

    public void SetAfraid()
    {
        currentState = NPCState.Fleeing;
    }

    public void SetCurious()
    {
        currentState = NPCState.Investigating;
    }

    public void ReturnToFollow()
    {
        currentState = NPCState.Following;
    }
}
