using UnityEngine;
using UnityEngine.UI;

public class LabelManager : MonoBehaviour
{
    [SerializeField]
    private Button showLabelsButton;

    [SerializeField]
    private PlacementObject[] placementObjects;

    private bool labelsVisible = false;

    void Start()
    {
        if (showLabelsButton != null)
        {
            showLabelsButton.onClick.AddListener(ToggleLabels);
        }
    }

    void ToggleLabels()
    {
        labelsVisible = !labelsVisible;

        foreach (var obj in placementObjects)
        {
            obj.ToggleOverlay(labelsVisible);
            obj.ToggleCanvas(labelsVisible);
        }
    }
}
