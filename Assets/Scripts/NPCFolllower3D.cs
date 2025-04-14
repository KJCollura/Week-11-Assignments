using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class FollowerNPC3D : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float followDistance = 6f;
    [SerializeField] private float stopDistance = 8f;
    [SerializeField] private float moveSpeed = 4f;

    private Rigidbody rb;
    private bool isFollowing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation;
    }

private void FixedUpdate()
{
    // Flatten both NPC and player position to ignore vertical differences
    Vector3 npcFlat = new Vector3(transform.position.x, 0f, transform.position.z);
    Vector3 playerFlat = new Vector3(player.position.x, 0f, player.position.z);

    Vector3 toPlayer = playerFlat - npcFlat;
    float distance = toPlayer.magnitude;

    if (distance <= followDistance)
        isFollowing = true;
    else if (distance >= stopDistance)
        isFollowing = false;

    if (isFollowing)
    {
        if (distance > 1f)
        {
            Vector3 direction = toPlayer.normalized;
            Vector3 moveVelocity = direction * moveSpeed;
            rb.linearVelocity = new Vector3(moveVelocity.x, 0f, moveVelocity.z); // <- lock vertical velocity
        }
        else
        {
            rb.linearVelocity = Vector3.zero;
        }
    }
    else
    {
        rb.linearVelocity = Vector3.zero;
    }
}
}