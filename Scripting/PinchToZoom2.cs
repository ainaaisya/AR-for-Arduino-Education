using UnityEngine;

public class PinchToZoom2 : MonoBehaviour
{
    public float zoomSpeed = 0.1f;
    public float minZoom = 0.2f;
    public float maxZoom = 5f;

    private float initialDistance;
    private Vector3 initialScale;
    private Vector3 lastScale;

    void Start()
    {
        lastScale = transform.localScale;
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
        else
        {
            // Ensure the scale is maintained when touches are lifted
            transform.localScale = lastScale;
        }
    }
}
