using UnityEngine;

public class MoodBasedClue : MonoBehaviour
{
    public enum MoodType { Blue, Orange, Purple }
    public MoodType requiredMood;

    private Renderer clueRenderer;

    private Color blueColor = Color.blue;
    private Color orangeColor = new Color(1f, 0.5f, 0f);
    private Color purpleColor = new Color(0.6f, 0f, 1f);
    private float threshold = 0.2f; // More forgiving

    void Start()
    {
        clueRenderer = GetComponentInChildren<Renderer>();
    }

    void Update()
    {
        Color ambient = RenderSettings.ambientLight;

        bool shouldShow = false;
        switch (requiredMood)
        {
            case MoodType.Blue: shouldShow = IsClose(ambient, blueColor); break;
            case MoodType.Orange: shouldShow = IsClose(ambient, orangeColor); break;
            case MoodType.Purple: shouldShow = IsClose(ambient, purpleColor); break;
        }

        clueRenderer.enabled = shouldShow;

        // Debug
        if (shouldShow)
            Debug.Log(gameObject.name + " is visible due to " + requiredMood);
    }

    private bool IsClose(Color a, Color b)
    {
        return Vector3.Distance(new Vector3(a.r, a.g, a.b), new Vector3(b.r, b.g, b.b)) < threshold;
    }
}
