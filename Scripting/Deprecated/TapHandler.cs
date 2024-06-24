using UnityEngine;
using UnityEngine.EventSystems;

public class TapHandler : MonoBehaviour, IPointerClickHandler
{
    private BlinkEffect blinkEffect;

    void Awake()
    {
        blinkEffect = GetComponent<BlinkEffect>();
        if (blinkEffect == null)
        {
            Debug.LogError("BlinkEffect component not found on this GameObject.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (blinkEffect != null)
        {
            blinkEffect.StartBlinking();
            Invoke("StopBlinking", 2f); // Stop blinking after 2 seconds, adjust as needed
        }
    }

    void StopBlinking()
    {
        if (blinkEffect != null)
        {
            blinkEffect.StopBlinking();
        }
    }
}
