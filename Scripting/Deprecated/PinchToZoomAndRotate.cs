using UnityEngine;

public class PinchToZoomAndRotate : MonoBehaviour
{
    [Header("Zoom Settings")]
    public float zoomSpeed = 0.1f;
    public float minZoom = 0.2f;
    public float maxZoom = 5f;

    [Header("Rotation Settings")]
    public float rotateSpeedModifier = 0.1f;

    private float initialDistance;
    private Vector3 initialScale;
    private Vector3 lastScale;
    private Vector2 lastTouchPosition;

    void Start()
    {
        lastScale = transform.localScale;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            HandleZoom();
        }
        else if (Input.touchCount == 1)
        {
            HandleRotation();
        }
        else
        {
            // Ensure the scale is maintained when touches are lifted
            transform.localScale = lastScale;
        }
    }

    private void HandleZoom()
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
        {
            initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
            initialScale = transform.localScale;
        }
        else if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
        {
            float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            if (Mathf.Approximately(initialDistance, 0))
            {
                return; // Avoid division by zero
            }

            float factor = currentDistance / initialDistance;

            Vector3 newScale = initialScale * factor;
            newScale.x = Mathf.Clamp(newScale.x, minZoom, maxZoom);
            newScale.y = Mathf.Clamp(newScale.y, minZoom, maxZoom);
            newScale.z = Mathf.Clamp(newScale.z, minZoom, maxZoom);

            transform.localScale = newScale;
            lastScale = newScale;
        }
    }

    private void HandleRotation()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            Vector2 deltaPosition = touch.deltaPosition * rotateSpeedModifier;

            // Rotate the object around the Y axis based on horizontal swipe
            transform.Rotate(Vector3.up, -deltaPosition.x, Space.Self);

            // Rotate the object around the X axis based on vertical swipe
            transform.Rotate(Vector3.right, deltaPosition.y, Space.Self);
        }
    }
}
