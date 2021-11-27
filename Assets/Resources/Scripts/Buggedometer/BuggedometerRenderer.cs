using UnityEngine;

public class BuggedometerRenderer : MonoBehaviour
{
    public SpriteRenderer Bar;
    private Vector3 Aim;
    private bool inProgress;
    private float Speed = 3;
    private float z;

    FMOD.Studio.EventInstance progressSound;
    public string path;

    void Awake()
    {
        z = Bar.transform.lossyScale.z;
        Bar.transform.localScale = new Vector3(1, 0, z);
    }

    public void Render(float currentPatience, float maxPatience)
    {
        if (currentPatience == maxPatience)
        {
            Aim = new Vector3(1, 0, z);
        }
        else if (currentPatience == 0)
        {
            Aim = new Vector3(1, 1, z);
        }
        else
        {  
            Aim = new Vector3(1, 1- (currentPatience / maxPatience), z);
        }
        inProgress = true;
    }

    void Update()
    {
        if (!inProgress) return;
        
        float step = Speed * Time.deltaTime;
        Bar.transform.localScale = Vector3.MoveTowards(Bar.transform.localScale, Aim, step);

        if (Bar.transform.localScale == Aim)
        {
            inProgress = false;

            FMODUnity.RuntimeManager.PlayOneShot(path);
        }
    }
}
