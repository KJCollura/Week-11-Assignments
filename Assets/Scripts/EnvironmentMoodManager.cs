using UnityEngine;

public class EnvironmentMoodManager : MonoBehaviour
{
    public GET_FirstPersonController playerController;
    public Light directionalLight;
    public float movementThreshold = 0.1f;
    public float transitionSpeed = 2f;

    private CharacterController characterController;

    void Start()
    {
        characterController = playerController.GetComponent<CharacterController>();
    }

    void Update()
    {
        float currentSpeed = characterController.velocity.magnitude;
        Color targetColor;

        bool isGrounded = IsGrounded();

        if (!isGrounded)
        {
            targetColor = new Color(0.6f, 0f, 1f); // Purple while in air
        }
        else if (currentSpeed < movementThreshold)
        {
            targetColor = Color.blue; // Idle
        }
        else
        {
            targetColor = new Color(1f, 0.5f, 0f); // Moving
        }

        directionalLight.color = Color.Lerp(directionalLight.color, targetColor, Time.deltaTime * transitionSpeed);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(playerController.transform.position, Vector3.down, playerController.GroundCheckDistance);
    }
}



