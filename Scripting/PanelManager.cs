using System.Collections.Generic;
using UnityEngine;

public class PanelManager : MonoBehaviour
{
    public static PanelManager Instance;

    private List<GameObject> registeredPanels = new List<GameObject>();
    private GameObject currentOpenPanel;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void RegisterPanel(GameObject panel)
    {
        if (!registeredPanels.Contains(panel))
        {
            registeredPanels.Add(panel);
        }
    }

    public void TogglePanel(GameObject panel)
    {
        if (currentOpenPanel == panel)
        {
            panel.SetActive(!panel.activeSelf);
        }
        else
        {
            if (currentOpenPanel != null)
            {
                currentOpenPanel.SetActive(false);
            }
            panel.SetActive(true);
            currentOpenPanel = panel;
        }
    }

    public void ResetCurrentOpenPanel(GameObject panel)
    {
        if (currentOpenPanel == panel)
        {
            currentOpenPanel = null;
        }
    }
}