using UnityEngine;

public class FallOut : MonoBehaviour
{
    private Vector3 Target;
    public float CustomSpeed = 0;
    private float Speed ;
    private bool Complete = true;
    public bool FallOnEnable = false;
    private int OffsetFall = 400;


    void Update()
    {
        if (Complete)
        {
            return;
        }

        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, Target, step);

        if(transform.position == Target)
        {
            Complete = true;
        }
    }


    public void Fallout()
    {
        if (CustomSpeed == 0)
        {
            Speed = Random.Range(100f, 300f);
        }
        else
        {
            Speed = CustomSpeed;
        }
        Target = transform.position;
        Target = transform.position - new Vector3(0, OffsetFall, 0);
        Complete = false;
    }
}