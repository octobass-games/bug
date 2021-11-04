using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Buggedometer : MonoBehaviour
{
    public int Patience;
    public int OutOfPatienceDelaySeconds;
    public UnityEvent OnOutOfPatience;

    private HashSet<GameObject> PatienceDroppers = new HashSet<GameObject>();

    public void DecrementPatience(GameObject gameObject)
    {
        if (!PatienceDroppers.Contains(gameObject))
        {
            Patience -= 1;
            PatienceDroppers.Add(gameObject);

            if (Patience == 0)
            {
                StartCoroutine(OutOfPatience());
            }
        }
    }

    private IEnumerator OutOfPatience()
    {
        yield return new WaitForSeconds(OutOfPatienceDelaySeconds);

        OnOutOfPatience.Invoke();
    }
}
