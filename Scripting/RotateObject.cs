using UnityEngine;
//From ChatGPT, but this contain mouse button

public class RotateObject : MonoBehaviour
{
    public float rotationSpeed = 100f;

    void Update()
    {
        // Check if the user is touching the screen or holding the mouse button
        if (Input.GetMouseButton(0))
        {
            float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
            float rotationY = Input.GetAxis("Mouse Y") * rotationSpeed * Time.deltaTime;

            // Rotate the object around the Y axis
            transform.Rotate(Vector3.down, rotationX);
            // Rotate the object around the X axis
            transform.Rotate(Vector3.right, rotationY);
        }

        // For touch input (single touch)
        if (Input.touchCount == 1)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * rotationSpeed * Time.deltaTime;
                float rotationY = touch.deltaPosition.y * rotationSpeed * Time.deltaTime;

                // Rotate the object around the Y axis
                transform.Rotate(Vector3.down, rotationX);
                // Rotate the object around the X axis
                transform.Rotate(Vector3.right, rotationY);
            }
        }
    }
}
