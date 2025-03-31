using UnityEngine;

public class GET_Raycast : MonoBehaviour
{
    public float range = 7f;

    void Update()
    {
        // Create a forward-facing ray from the player's transform
        Vector3 direction = transform.forward;
        Ray playerRay = new Ray(transform.position, direction);

        // Debug the ray visually in the Scene view
        Debug.DrawRay(transform.position, direction * range, Color.red);

        // Fire the raycast, ignoring "MoodClue" tagged objects
        if (Physics.Raycast(playerRay, out RaycastHit hit, range))
        {
            // Ignore mood clue objects
            if (hit.collider.CompareTag("MoodClue"))
            {
                return;
            }

            // Handle other object types
            if (hit.collider.CompareTag("Static"))
            {
                Debug.Log("Raycast hit a STATIC object");
            }
            else if (hit.collider.CompareTag("Enemy"))
            {
                Debug.Log("Raycast hit an ENEMY object");

                Renderer hitRenderer = hit.collider.GetComponent<Renderer>();
                if (hitRenderer != null)
                {
                    hitRenderer.material.color = GetRandomColor();
                }
            }
        }
    }

    // Helper to generate a random color
    Color GetRandomColor()
    {
        return new Color(Random.value, Random.value, Random.value);
    }
}
