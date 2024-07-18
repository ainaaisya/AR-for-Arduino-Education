using UnityEngine;
using UnityEngine.UI;

public class LabelManager : MonoBehaviour
{
    [SerializeField]
    private Button showLabelsButton;

    [SerializeField]
    private Button hideLabelsButton;

    [SerializeField]
    private PlacementObject[] placementObjects;

    void Start()
    {
        if (showLabelsButton != null)
        {
            showLabelsButton.onClick.AddListener(ShowLabels);
        }

        if (hideLabelsButton != null)
        {
            hideLabelsButton.onClick.AddListener(HideLabels);
            hideLabelsButton.gameObject.SetActive(false); // Hide the Hide button initially
        }
		
		// Ensure blue labels are shown initially
        ShowLabels();
    }

    void ShowLabels()
    {
        Debug.Log("ShowLabels button clicked.");
		
        ToggleLabels(true);
        showLabelsButton.gameObject.SetActive(false);
        hideLabelsButton.gameObject.SetActive(true);
    }

    void HideLabels()
    {
        Debug.Log("HideLabels button clicked.");
		
        ToggleLabels(false);
        showLabelsButton.gameObject.SetActive(true);
        hideLabelsButton.gameObject.SetActive(false);
    }

    void ToggleLabels(bool state)
    {
        Debug.Log($"ToggleLabels called with state: {state}");
		
        foreach (var obj in placementObjects)
        {
            obj.ToggleOverlay(state);
            obj.ToggleCanvas(state);
        }
    }
}
