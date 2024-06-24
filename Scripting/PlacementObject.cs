using TMPro;
using UnityEngine;

public class PlacementObject : MonoBehaviour
{
    [SerializeField]
    private bool isSelected;

    [SerializeField]
    private TextMeshPro overlayText;
	
    [SerializeField]
    private Canvas canvasComponent;

    [SerializeField]
    private string overlayDisplayText;

    public bool Selected 
    { 
        get => isSelected;
        set => isSelected = value;
    }

    public void SetOverlayText(string text)
    {
        if (overlayText != null)
        {
            overlayText.gameObject.SetActive(true);
            overlayText.text = text;
        }
    }

    void Awake ()
    {
        overlayText = GetComponentInChildren<TextMeshPro>();
        if (overlayText != null)
        {
            overlayText.gameObject.SetActive(false);
        }
    }

    public void ToggleOverlay(bool state)
    {
        Debug.Log($"ToggleOverlay called with state: {state}");
		
        if (overlayText != null)
        {
            overlayText.gameObject.SetActive(state);
            overlayText.text = overlayDisplayText;
        }
    }

    public void ToggleCanvas(bool state)
    {
        Debug.Log($"ToggleCanvas called with state: {state}");
        
        if (canvasComponent != null)
        {
            canvasComponent.gameObject.SetActive(state);
        }
    }

}
