using System.Collections;
using UnityEngine;
using UnityEngine.Serialization;

public class Fall : MonoBehaviour
{
    public Transform InitialPosition;
    public Transform RestingPosition;
    public Transform FinalPosition;
    public float Speed = 1;
    public float PreFallDelaySeconds;
    public bool IsFallingToRestingPosition = false;
    public bool InitialRoom;

    private bool IsPushing;
    public Transform TargetPosition;

    void Update()
    {
        if (IsPushing)
        {
            float step = Speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, TargetPosition.position, step);

            if (transform.position == TargetPosition.position)
            {
                IsPushing = false;

                if (TargetPosition == RestingPosition)
                {
                    TargetPosition = FinalPosition;
                }
                else
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
    void OnEnable()
    {
        transform.position = InitialPosition.position;

        TargetPosition = RestingPosition;

        Push();
    }

    public void Push()
    {
        StartCoroutine(StartPushing());
    }

    private IEnumerator StartPushing()
    {
        yield return new WaitForSeconds(TargetPosition == RestingPosition ? 0 : PreFallDelaySeconds);

        IsPushing = true;
    }
}