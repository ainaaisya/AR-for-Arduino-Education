using UnityEngine;
using UnityEngine.UI;

public class DescriptionManager : MonoBehaviour
{
    [SerializeField]
    private Button showDescriptionButton;
	
	[SerializeField]
    private Button hideDescriptionButton;

    [SerializeField]
    private PlacementObject[] placementObjects;

    void Start()
    {
        if (showDescriptionButton != null)
        {
            showDescriptionButton.onClick.AddListener(ShowDesc);
        }

        if (hideDescriptionButton != null)
        {
            hideDescriptionButton.onClick.AddListener(HideDesc);
            hideDescriptionButton.gameObject.SetActive(false); // Hide the Hide button initially
        }
    }

    void ShowDesc()
    {
        Debug.Log("ShowDesc button clicked.");
		
        ToggleLabels(true);
        showDescriptionButton.gameObject.SetActive(false);
        hideDescriptionButton.gameObject.SetActive(true);
    }

    void HideDesc()
    {
        Debug.Log("HideDesc button clicked.");
		
        ToggleLabels(false);
        showDescriptionButton.gameObject.SetActive(true);
        hideDescriptionButton.gameObject.SetActive(false);
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
