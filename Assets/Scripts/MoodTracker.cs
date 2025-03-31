using UnityEngine;

public class MoodTracker : MonoBehaviour
{
    public float timeInBlue = 0f;
    public float timeInOrange = 0f;
    public float timeInPurple = 0f;

    private Color blueColor = Color.blue;
    private Color orangeColor = new Color(1f, 0.5f, 0f);
    private Color purpleColor = new Color(0.6f, 0f, 1f);
    private float colorMatchThreshold = 0.1f;

    void Update()
    {
        Color current = RenderSettings.ambientLight;

        if (IsSimilarColor(current, blueColor))
        {
            timeInBlue += Time.deltaTime;
        }
        else if (IsSimilarColor(current, orangeColor))
        {
            timeInOrange += Time.deltaTime;
        }
        else if (IsSimilarColor(current, purpleColor))
        {
            timeInPurple += Time.deltaTime;
        }
    }

    private bool IsSimilarColor(Color a, Color b)
    {
        return Vector3.Distance(new Vector3(a.r, a.g, a.b), new Vector3(b.r, b.g, b.b)) < colorMatchThreshold;
    }

    public string GetDominantMood()
    {
        if (timeInBlue >= timeInOrange && timeInBlue >= timeInPurple)
            return "Blue";
        if (timeInOrange >= timeInBlue && timeInOrange >= timeInPurple)
            return "Orange";
        return "Purple";
    }
}
