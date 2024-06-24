using UnityEngine;

public class BlinkEffect : MonoBehaviour
{
    public Color startColor = Color.yellow;
    public Color endColor = Color.black;
    [Range(0, 10)]
    public float speed = 1;
    
    private Renderer ren;
    private bool isBlinking = false;
    private float blinkStartTime;

    void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    void Update()
    {
        if (isBlinking)
        {
            float t = (Time.time - blinkStartTime) * speed;
            ren.material.color = Color.Lerp(startColor, endColor, Mathf.PingPong(t, 1));
        }
    }

    public void StartBlinking()
    {
        isBlinking = true;
        blinkStartTime = Time.time;
    }

    public void StopBlinking()
    {
        isBlinking = false;
        ren.material.color = startColor; // or any default color
    }
}
