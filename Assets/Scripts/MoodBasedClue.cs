using UnityEngine;

public class MoodBasedClue : MonoBehaviour
{
    public enum MoodType { Blue, Orange, Purple }
    public MoodType requiredMood;

    private Renderer clueRenderer;

    private Color blueColor = Color.blue;
    private Color orangeColor = new Color(1f, 0.5f, 0f);
    private Color purpleColor = new Color(0.6f, 0f, 1f);
    private float tolerance = 0.25f; // Adjust as needed for looser or tighter color match

    void Start()
    {
        clueRenderer = GetComponentInChildren<Renderer>();
        if (clueRenderer == null)
        {
            Debug.LogWarning("MoodBasedClue: No Renderer found on " + gameObject.name);
        }
    }

    void Update()
    {
        Color ambient = RenderSettings.ambientLight;

        // Debug the ambient light color
        Debug.Log("Ambient Light: " + ambient);

        bool showClue = false;

        switch (requiredMood)
        {
            case MoodType.Blue:
                showClue = IsCloseTo(ambient, blueColor);
                break;
            case MoodType.Orange:
                showClue = IsCloseTo(ambient, orangeColor);
                break;
            case MoodType.Purple:
                showClue = IsCloseTo(ambient, purpleColor);
                break;
        }

        if (clueRenderer != null)
        {
            clueRenderer.enabled = showClue;

            if (showClue)
            {
                Debug.Log(gameObject.name + " is VISIBLE in mood: " + requiredMood);
            }
        }
    }

    private bool IsCloseTo(Color a, Color b)
    {
        return Mathf.Abs(a.r - b.r) < tolerance &&
               Mathf.Abs(a.g - b.g) < tolerance &&
               Mathf.Abs(a.b - b.b) < tolerance;
    }
}
