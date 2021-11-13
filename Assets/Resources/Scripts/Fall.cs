using System.Collections;
using UnityEngine;

public class Fall : MonoBehaviour
{
    public Transform Destination;
    public float Speed;
    public float Delay;

    private bool IsPushing;

    void Update()
    {
        if (IsPushing)
        {
            float step = Speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, Destination.position, step);

            if (transform.position == Destination.position)
            {
                IsPushing = false;
            }
        }
    }

    public void Push()
    {
        StartCoroutine(StartPushing());
    }

    private IEnumerator StartPushing()
    {
        yield return new WaitForSeconds(Delay);

        IsPushing = true;
    }
}
