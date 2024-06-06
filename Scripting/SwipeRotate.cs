/*using UnityEngine;
//From Youtube tutorial. Rotate with finger swipe

public class SwipeRotate : MonoBehaviour
{
	private Touch touch;
	private Vector2 touchPosition;
	private float rotateSpeedModifier = 0.1f;
	
	//Update is called once per frame 
	void Update()
	{
        if (Input.touchCount == 1)
		{
			touch = Input.GetTouch(0);
			
			if(touch.phase == TouchPhase.Moved)
			{
				rotationY = Quaternion.Euler(0f, - touch.deltaPosition.x * rotateSpeedModifier, 0f);
					
				transform.rotation = rotationY * transform.rotation;
			}
		}
		
		if (touch.phase == TouchPhase.Moved)
		{
			float rotationX = touch.deltaPosition.x * rotateSpeedModifier;
			float rotationY = touch.deltaPosition.y * rotateSpeedModifier;
			
			// Rotate the object around the Y axis based on horizontal swipe
			transform.Rotate(Vector3.up, -rotationX, Space.World);
			
			// Rotate the object around the X axis based on vertical swipe
			//transform.Rotate(Vector3.right, rotationY, Space.World);
			transform.Rotate(Camera.main.transform.right, rotationY, Space.World);
		}
	}
}*/


using UnityEngine;

public class SwipeRotate : MonoBehaviour
{
    private Touch touch;
    private Vector2 touchPosition;
    private float rotateSpeedModifier = 0.1f;

    // Update is called once per frame 
    void Update()
    {
        if (Input.touchCount == 1)
        {
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Moved)
            {
                float rotationX = touch.deltaPosition.x * rotateSpeedModifier;
                float rotationY = touch.deltaPosition.y * rotateSpeedModifier;

                // Rotate the object around the Y axis based on horizontal swipe
                transform.Rotate(Vector3.up, -rotationX, Space.Self);

                // Rotate the object around the X axis based on vertical swipe
                transform.Rotate(Vector3.right, rotationY, Space.Self);
            }
        }
    }
}
