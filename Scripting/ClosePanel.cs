using UnityEngine;
using UnityEngine.UI;

public class ClosePanel : MonoBehaviour
{
    public GameObject[] infoPanels; // Array of all info panels
    public GameObject[] labels; // Array of all labels (both blue and green)

    public void CloseInfo(int panelIndex)
    {
        if (panelIndex >= 0 && panelIndex < infoPanels.Length)
        {
            infoPanels[panelIndex].SetActive(false); // Close the specified info panel

            // Reset the corresponding green label back to blue
            int labelIndex = panelIndex % (labels.Length / 2); // Calculate label index from panel index
            labels[labelIndex].SetActive(true); // Activate the blue label
            labels[labelIndex + labels.Length / 2].SetActive(false); // Deactivate the green label
        }
    }

    public void CloseAllInfoPanels()
    {
        foreach (var panel in infoPanels)
        {
            panel.SetActive(false); // Close all info panels
        }

        // Reset all green labels back to blue
        for (int i = 0; i < labels.Length / 2; i++)
        {
            labels[i].SetActive(true); // Activate the blue label
            labels[i + labels.Length / 2].SetActive(false); // Deactivate the green label
        }
    }
}
