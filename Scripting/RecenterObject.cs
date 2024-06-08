using UnityEngine;

public class RecenterObject : MonoBehaviour
{
	public Camera mainCamera;
	
	void Start()
	{
		if(mainCamera == null)
		{
			mainCamera = Camera.main;
		}
	}
	
	void Update()
	{
		RecenterToScreen();
	}
	
	private void RecenterToScreen()
	{
		if(mainCamera != null)
		{
			Vector3 screenCenter = new Vector3(Screen.width/2, Screen.height/2, mainCamera.nearClipPlane);
			Vector3 worldCenter = mainCamera.ScreenToWorldPoint(screenCenter);
			transform.position = new Vector3(worldCenter.x, worldCenter.y, transform.position.z);
		}
	}
}