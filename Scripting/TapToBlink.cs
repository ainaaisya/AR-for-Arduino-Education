using UnityEngine;
using UnityEngine.EventSystems;

public class TapToBlink : MonoBehaviour, IPointerClickHandler
{
    private Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
        if (animator == null)
        {
            Debug.LogError("Animator component not found on this GameObject.");
        }
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (animator != null)
        {
            animator.SetTrigger("Blink");
        }
    }
}
