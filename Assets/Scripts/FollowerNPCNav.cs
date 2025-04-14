using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class FollowerNPCNav : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followDistance = 6f;
    [SerializeField] private float stopDistance = 8f;

    private NavMeshAgent agent;
    private bool isFollowing;

    private void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance <= followDistance)
            isFollowing = true;
        else if (distance >= stopDistance)
            isFollowing = false;

        if (isFollowing)
        {
            if (distance > agent.stoppingDistance)
                agent.SetDestination(player.position);
            else
                agent.ResetPath();
        }
        else
        {
            agent.ResetPath();
        }
    }
}
