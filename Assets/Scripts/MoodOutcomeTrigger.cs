using UnityEngine;

public class MoodOutcomeTrigger : MonoBehaviour
{
    public MoodTracker moodTracker;

    // You can replace these with scene transitions, dialogue triggers, animations, etc.
    public GameObject blueEndingObject;
    public GameObject orangeEndingObject;
    public GameObject purpleEndingObject;

    private bool hasTriggered = false;

    void OnTriggerEnter(Collider other)
    {
    if (hasTriggered) return;

    if (other.CompareTag("Player"))
    {
        string mood = moodTracker.GetDominantMood();
        Debug.Log("Mood Outcome Triggered — Dominant Mood: " + mood);
        Debug.Log("Times — Blue: " + moodTracker.timeInBlue + ", Orange: " + moodTracker.timeInOrange + ", Purple: " + moodTracker.timeInPurple);

        if (mood == "Blue" && blueEndingObject != null)
            blueEndingObject.SetActive(true);
        else if (mood == "Orange" && orangeEndingObject != null)
            orangeEndingObject.SetActive(true);
        else if (mood == "Purple" && purpleEndingObject != null)
            purpleEndingObject.SetActive(true);

        hasTriggered = true;
        }
    }
}
