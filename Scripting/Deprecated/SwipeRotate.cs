using UnityEngine;

public class SwipeRotate : MonoBehaviour
{
    public float rotateSpeedModifier = 0.1f;

    void Update()
    {
        if (Input.touchCount == 1)
        {
            HandleRotation();
        }
    }

    private void HandleRotation()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            Vector2 deltaPosition = touch.deltaPosition * rotateSpeedModifier;

            // Rotate the object around the Y axis based on horizontal swipe
            transform.Rotate(Vector3.up, -deltaPosition.x, Space.World);

            // Rotate the object around the X axis based on vertical swipe
            transform.Rotate(Vector3.right, deltaPosition.y, Space.Self);
        }
    }
}
