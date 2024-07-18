using UnityEngine;

public class LabelInteraction : MonoBehaviour
{
    public int labelIndex; // Index of the label (for example: 0 for Label 1, 1 for Label 2, etc.)
    public GameObject[] labels; // Array of all labels (both blue and green)
    public GameObject[] infoPanels; // Array of corresponding information panels

    void Start()
    {
        // Ensure all labels and info panels are hidden initially
        foreach (GameObject label in labels)
        {
            label.SetActive(true); // All labels start as active (blue state)
        }
        foreach (GameObject panel in infoPanels)
        {
            panel.SetActive(false);
        }
    }

    void OnMouseDown()
    {
        // Toggle between blue and green label states, and activate/deactivate corresponding panels
        if (labels[labelIndex].activeSelf) // If the clicked label is blue
        {
            labels[labelIndex].SetActive(false); // Deactivate the blue label
            labels[labelIndex + labels.Length / 2].SetActive(true); // Activate the corresponding green label
            infoPanels[labelIndex].SetActive(true); // Activate the corresponding info panel
        }
        else // If the clicked label is green
        {
            labels[labelIndex].SetActive(true); // Activate the blue label
            labels[labelIndex + labels.Length / 2].SetActive(false); // Deactivate the corresponding green label
            infoPanels[labelIndex].SetActive(false); // Deactivate the corresponding info panel
        }

        // Ensure only one panel (info or description) is active at a time
        foreach (GameObject panel in infoPanels)
        {
            if (panel.activeSelf && panel != infoPanels[labelIndex])
            {
                panel.SetActive(false);
            }
        }
    }
}
