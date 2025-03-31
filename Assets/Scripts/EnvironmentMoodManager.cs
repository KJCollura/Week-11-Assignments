using UnityEngine;

public class EnvironmentMoodManager : MonoBehaviour
{
    public GET_FirstPersonController playerController;
    public Light directionalLight;
    public float transitionSpeed = 2f;
    public float movementThreshold = 0.1f;

    private CharacterController characterController;
    private Color targetColor;

    void Start()
    {
        characterController = playerController.GetComponent<CharacterController>();
    }

    void Update()
    {
        // TEMP: Comment this in to test clues directly
        // RenderSettings.ambientLight = new Color(1f, 0.5f, 0f); // Force Orange
        // return;

        float currentSpeed = characterController.velocity.magnitude;
        bool isGrounded = IsGrounded();

        if (!isGrounded)
        {
            targetColor = new Color(0.6f, 0f, 1f); // Purple (Jumping)
        }
        else if (currentSpeed < movementThreshold)
        {
            targetColor = Color.blue; // Idle
        }
        else
        {
            targetColor = new Color(1f, 0.5f, 0f); // Orange (Moving)
        }

        // Transition light and ambient light smoothly
        directionalLight.color = Color.Lerp(directionalLight.color, targetColor, Time.deltaTime * transitionSpeed);
        RenderSettings.ambientLight = Color.Lerp(RenderSettings.ambientLight, targetColor, Time.deltaTime * transitionSpeed);

        // Debug logs
        Debug.Log("MoodManager: Target Color = " + targetColor);
        Debug.Log("Current Ambient Light: " + RenderSettings.ambientLight);
    }

    private bool IsGrounded()
    {
        return Physics.Raycast(playerController.transform.position, Vector3.down, playerController.GroundCheckDistance);
    }
}




