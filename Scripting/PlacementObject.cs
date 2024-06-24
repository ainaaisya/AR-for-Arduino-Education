using TMPro;
using UnityEngine;

public class PlacementObject : MonoBehaviour
{
    [SerializeField]
    private bool isSelected;

    [SerializeField]
    private bool isLocked;

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

    public bool Locked 
    { 
        get => isLocked;
        set => isLocked = value;
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
        if (overlayText != null)
        {
            overlayText.gameObject.SetActive(state);
            overlayText.text = overlayDisplayText;
        }
    }

    public void ToggleCanvas(bool state)
    {
        if (canvasComponent != null)
        {
            canvasComponent.gameObject.SetActive(state);
        }
    }
}
