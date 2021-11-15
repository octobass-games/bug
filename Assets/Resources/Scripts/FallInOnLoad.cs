using UnityEngine;

public class FallInOnLoad : MonoBehaviour
{
    public float CustomSpeed = 0;

    private Vector3 ScenePosition;
    private Vector3 TargetPosition;
    private bool IsFalling = false;

    void Awake()
    {
        ScenePosition = transform.position;
        CustomSpeed = CustomSpeed == 0 ? Random.Range(50f, 150f) : CustomSpeed;
        FallIn();
    }

    void Update()
    {
        if (IsFalling)
        {
            Fall();
        }
    }

    private void Fall()
    {
        float step = CustomSpeed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, TargetPosition, step);

        if (transform.position == TargetPosition)
        {
            IsFalling = false;
        }
    }


    public void FallIn()
    {
        TargetPosition = ScenePosition;
        transform.position = ScenePosition + new Vector3(0, 100, 0);
        IsFalling = true;
    }

    public void FallOut()
    {
        TargetPosition = transform.position - new Vector3(0, 400, 0);
        IsFalling = true;
    }
}