using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buggedometer : MonoBehaviour
{
    public int Patience;
    private int MaxPatience;
    public int OutOfPatienceDelaySeconds;
    public UnityEvent OnOutOfPatience;
    public BuggedometerRenderer BuggedometerRenderer;

    private HashSet<GameObject> PatienceDroppers = new HashSet<GameObject>();
    private HashSet<GameObject> PatienceAdders = new HashSet<GameObject>();

    void Awake()
    {
        MaxPatience = Patience;
    }

    public void DecrementPatience(GameObject gameObject)
    {
        if (!PatienceDroppers.Contains(gameObject))
        {
            Patience -= 1;
            PatienceDroppers.Add(gameObject);

            BuggedometerRenderer.Render(Patience, MaxPatience);

            if (PatienceAdders.Contains(gameObject))
            {
                PatienceAdders.Remove(gameObject);
            }

            if (Patience == 0)
            {
                StartCoroutine(OutOfPatience());
            }
        }
    }


    public void IncrementPatience(GameObject gameObject)
    {
        if (PatienceDroppers.Contains(gameObject) && !PatienceAdders.Contains(gameObject) && Patience != MaxPatience)
        {
            Patience += 1;
            PatienceAdders.Add(gameObject);
            PatienceDroppers.Remove(gameObject);

            BuggedometerRenderer.Render(Patience, MaxPatience);
        }
    }


    private IEnumerator OutOfPatience()
    {
        yield return new WaitForSeconds(OutOfPatienceDelaySeconds);

        OnOutOfPatience.Invoke();
    }
}
