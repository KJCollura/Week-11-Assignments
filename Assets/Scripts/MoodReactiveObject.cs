using UnityEngine;

public class MoodReactiveObject : MonoBehaviour
{
    public Renderer objectRenderer;
    public float colorLerpSpeed = 2f;

    void Start()
    {
        if (objectRenderer == null)
        objectRenderer = GetComponent<Renderer>();

        // Create a material instance so changes don't affect shared materials
        objectRenderer.material = new Material(objectRenderer.material);
    }


    void Update()
    {
    Color targetColor = RenderSettings.ambientLight;
    Color currentColor = objectRenderer.material.color;

    Color newColor = Color.Lerp(currentColor, targetColor, Time.deltaTime * colorLerpSpeed);
    objectRenderer.material.color = newColor;

    // Set emission (make sure material has emission enabled)
    objectRenderer.material.SetColor("_EmissionColor", newColor * 1.5f);
    }

}