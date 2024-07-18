using UnityEngine;

public class ToggleLabels : MonoBehaviour
{
    public GameObject[] blueLabels; // Array to hold the default (blue) labels
    public GameObject[] greenLabels; // Array to hold the active (green) labels
    public GameObject showLabelsButton; // Reference to the Show Labels button
    public GameObject hideLabelsButton; // Reference to the Hide Labels button
    private bool labelsVisible = false; // Track the visibility of the labels
    private int currentLabelIndex = -1; // Track the current active label (-1 means no active label)

    void Start()
    {
        // Ensure labels are hidden and the correct button is visible at start
        SetLabelsActive(labelsVisible);
        showLabelsButton.SetActive(true);
        hideLabelsButton.SetActive(false);
    }

    public void ToggleLabelVisibility()
    {
        labelsVisible = !labelsVisible; // Toggle the visibility state
        SetLabelsActive(labelsVisible);

        // Toggle button visibility
        showLabelsButton.SetActive(!labelsVisible);
        hideLabelsButton.SetActive(labelsVisible);
    }

    private void SetLabelsActive(bool active)
    {
        foreach (GameObject label in blueLabels)
        {
            label.SetActive(active); // Set each default label's active state based on the visibility state
        }
        foreach (GameObject label in greenLabels)
        {
            label.SetActive(false); // Ensure active labels are hidden initially
        }
    }

    public void ChangeLabelSprite(int labelIndex)
    {
        if (labelsVisible)
        {
            // Deactivate the current active label if there is one
            if (currentLabelIndex >= 0)
            {
                blueLabels[currentLabelIndex].SetActive(true);
                greenLabels[currentLabelIndex].SetActive(false);
            }

            // Activate the new active label
            blueLabels[labelIndex].SetActive(false);
            greenLabels[labelIndex].SetActive(true);

            // Update the current label index
            currentLabelIndex = labelIndex;
        }
    }
}
