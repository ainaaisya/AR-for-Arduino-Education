//from chatgpt but other configuration is needed in unity for information card UIs

using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TapHandler : MonoBehaviour, IPointerClickHandler
{
    public GameObject infoPanel; // The UI panel to display information
    public Text infoText; // The UI text component to display the information text
    public string objectInfo; // The information to display for this object

    private float lastTapTime;
    private const float doubleTapThreshold = 0.3f;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (Time.time - lastTapTime < doubleTapThreshold)
        {
            // Double-tap detected
            DisplayInformation();
        }
        else
        {
            // Single tap detected
            Invoke("HandleSingleTap", doubleTapThreshold);
        }
        lastTapTime = Time.time;
    }

    void HandleSingleTap()
    {
        if (Time.time - lastTapTime >= doubleTapThreshold)
        {
            // Single tap confirmed
            DisplayInformation();
        }
    }

    void DisplayInformation()
    {
        infoPanel.SetActive(true);
        infoText.text = objectInfo;
    }
}
