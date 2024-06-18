using UnityEngine;

public class RecenterObject : MonoBehaviour
{
    public Camera mainCamera;
    public float offset = 7.0f; // Small offset to prevent overlap with the camera


    void Start()
    {
        // Automatically assign the main camera if not set
        if (mainCamera == null)
        {
            mainCamera = Camera.main;
        }
    }

    void Update()
    {
        // Check if the mainCamera is assigned
        if (mainCamera != null)
        {
            // Calculate the position in front of the camera
            Vector3 newPosition = mainCamera.transform.position + mainCamera.transform.forward * offset;

            // Set the position of the model
            transform.position = newPosition;

        }
    }
}
