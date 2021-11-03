using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Buggedometer : MonoBehaviour
{
    public int Patience;
    public int OutOfPatienceDelaySeconds;
    public UnityEvent OnOutOfPatience;

    public void DecrementPatience()
    {
        Patience -= 1;

        if (Patience == 0)
        {
            StartCoroutine(OutOfPatience());
        }
    }

    private IEnumerator OutOfPatience()
    {
        yield return new WaitForSeconds(OutOfPatienceDelaySeconds);

        OnOutOfPatience.Invoke();
    }
}
