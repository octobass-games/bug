using UnityEngine;

public class BuggedometerRenderer : MonoBehaviour
{
    public SpriteRenderer Bar;

    void Awake()
    {
        Bar.transform.localScale = new Vector2(1, 0);
    }

    public void Render(float currentPatience, float maxPatience)
    {
        if (currentPatience == maxPatience)
        {
            Bar.transform.localScale = new Vector2(1, 0);
        }
        else if (currentPatience == 0)
        {
            Bar.transform.localScale = new Vector2(1, 1);
        }
        else
        {  
            Bar.transform.localScale = new Vector2(1, 1- (currentPatience / maxPatience));
        }
    }
}
