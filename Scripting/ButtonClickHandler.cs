using UnityEngine;

public class ButtonClickHandler : MonoBehaviour
{
    public Animator animator; // Reference to the Animator component

    public void OnButtonClick()
    {
        // Trigger the animation
        animator.SetTrigger("BlinkController");
    }
}