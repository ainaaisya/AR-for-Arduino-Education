using UnityEngine;

public class PinchToZoom2 : MonoBehaviour
{
    public float zoomSpeed = 0.1f;
    public float minZoom = 0.2f;
    public float maxZoom = 4f;

    private float initialDistance;
    private Vector3 initialScale;
    private Vector3 lastScale;

    void Start()
    {
        initialScale = transform.localScale; // Store initial scale
        lastScale = initialScale;
    }

    void Update()
    {
        if (Input.touchCount == 2)
        {
            Touch touchZero = Input.GetTouch(0);
            Touch touchOne = Input.GetTouch(1);

            if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
            {
                initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
            }
            else if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
            {
                float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

                if (Mathf.Approximately(initialDistance, 0))
                {
                    return; // Avoid division by zero
                }

                float factor = currentDistance / initialDistance;

                // Calculate new scale uniformly
                float newScaleFactor = Mathf.Clamp(lastScale.x * factor, minZoom, maxZoom);
                Vector3 newScale = new Vector3(newScaleFactor, newScaleFactor, newScaleFactor);

                transform.localScale = newScale;
                lastScale = newScale;
            }
        }
    }
}
