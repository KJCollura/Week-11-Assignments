using UnityEngine;

public class PlayerColorChanger : MonoBehaviour
{
    public float runSpeedThreshold = 3f;
    private CharacterController controller;
    private Renderer rend;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        float speed = controller.velocity.magnitude;

        if (speed < 0.1f)
            rend.material.color = Color.white;
        else if (speed < runSpeedThreshold)
            rend.material.color = Color.green;
        else
            rend.material.color = Color.red;
    }
}
