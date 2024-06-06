using UnityEngine;

public class ZoomRotateOrbit : MonoBehaviour
{
    [Header("Zoom Settings")]
    public float zoomSpeed = 0.1f;
    public float minFOV = 15f;
    public float maxFOV = 90f;
    /*public float minZoom = 0.2f;
    public float maxZoom = 5f;*/

    [Header("Rotation Settings")]
    public float rotateSpeedModifier = 0.1f;

    private float initialDistance;
	private Camera arCamera;
    //private Vector3 initialScale;
   // private Vector3 lastScale;
   // private Vector2 lastTouchPosition;
    //private Transform cameraTransform;

    void Start()
    {
        /*cameraTransform = Camera.main.transform;
        lastScale = cameraTransform.localScale;*/
		arCamera = Camera.main;
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
    }

    private void HandleZoom()
    {
        Touch touchZero = Input.GetTouch(0);
        Touch touchOne = Input.GetTouch(1);

        if (touchZero.phase == TouchPhase.Began || touchOne.phase == TouchPhase.Began)
        {
            initialDistance = Vector2.Distance(touchZero.position, touchOne.position);
           // initialScale = cameraTransform.localScale;
        }
        else if (touchZero.phase == TouchPhase.Moved || touchOne.phase == TouchPhase.Moved)
        {
            float currentDistance = Vector2.Distance(touchZero.position, touchOne.position);

            if (Mathf.Approximately(initialDistance, 0))
            {
                return; // Avoid division by zero
            }

            float factor = currentDistance / initialDistance;
			
			float newFOV = arCamera.fieldOfView / factor;
            newFOV = Mathf.Clamp(newFOV, minFOV, maxFOV);

            arCamera.fieldOfView = newFOV;

           /* Vector3 newScale = initialScale * factor;
            newScale.x = Mathf.Clamp(newScale.x, minZoom, maxZoom);
            newScale.y = Mathf.Clamp(newScale.y, minZoom, maxZoom);
            newScale.z = Mathf.Clamp(newScale.z, minZoom, maxZoom);

            cameraTransform.localScale = newScale;
            lastScale = newScale;*/
        }
    }

    private void HandleRotation()
    {
        Touch touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Moved)
        {
            Vector2 deltaPosition = touch.deltaPosition * rotateSpeedModifier;

            // Rotate the orbit (empty GameObject) around the Y axis based on horizontal swipe
            transform.Rotate(Vector3.up, -deltaPosition.x, Space.World);

            // Rotate the orbit around the local X axis based on vertical swipe
            transform.Rotate(Vector3.right, deltaPosition.y, Space.Self);
        }
    }
}
