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

    private void Awake()
    {
        transform.position = InitialPosition.position;
    }

    private void Start()
    {
        if (InitialRoom)
        {
            Push();
        }
    }

    void Update()
    {
        if (IsPushing)
        {
            var destination = IsFallingToRestingPosition ? RestingPosition : FinalPosition;

            float step = Speed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, destination.position, step);

            if (transform.position == destination.position)
            {
                IsPushing = false;

                bool isAtFinalPosition = !IsFallingToRestingPosition;

                if (isAtFinalPosition)
                {
                    transform.position = InitialPosition.position;
                    IsFallingToRestingPosition = true;
                    gameObject.SetActive(false);
                }
                else
                {
                    IsFallingToRestingPosition = false;
                }
            }
        }
    }

    public void Push()
    {
        StartCoroutine(StartPushing());
    }

    private IEnumerator StartPushing()
    {
        yield return new WaitForSeconds(PreFallDelaySeconds);

        IsPushing = true;
    }
}