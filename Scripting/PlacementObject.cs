using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlacementObject : MonoBehaviour
{
    [SerializeField]
    private bool isSelected;

    [SerializeField]
    private TextMeshPro overlayText;
	
	[SerializeField]
    private TextMeshProUGUI descriptionText;
	
    [SerializeField]
    private Image descriptionBox;
	
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

        if (descriptionText != null)
        {
            descriptionText.gameObject.SetActive(true);
            descriptionText.text = text;
        }
    }

    void Awake ()
    {
        overlayText = GetComponentInChildren<TextMeshPro>();
        descriptionText = GetComponentInChildren<TextMeshProUGUI>();
        descriptionBox = GetComponentInChildren<Image>();
		
        if (overlayText != null)
        {
            overlayText.gameObject.SetActive(false);
        }

        if (descriptionText != null)
        {
            descriptionText.gameObject.SetActive(false);
        }

        if (descriptionBox != null)
        {
            descriptionBox.gameObject.SetActive(false);
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
		

        if (descriptionText != null)
        {
            descriptionText.gameObject.SetActive(state);
            descriptionText.text = overlayDisplayText;
        }

        if (descriptionBox != null)
        {
            descriptionBox.gameObject.SetActive(state);
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
