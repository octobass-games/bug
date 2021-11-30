using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject Camera;
    public bool IsInitialRoom;

    private Coroutine FallingOutCoroutine;

    public void FallIn(Door door)
    {
        if (FallingOutCoroutine != null)
        {
            StopCoroutine(FallingOutCoroutine);
        }

        var fallIns = GetComponentsInChildren<Fall>().ToList();
        fallIns.Remove(door.GetComponent<Fall>());

        fallIns.ForEach(fallIn => fallIn.FallIn());
    }

    public void FallOut()
    {
        var fallIns = GetComponentsInChildren<Fall>().ToList();

        FallingOutCoroutine = StartCoroutine(WaitThen(() => fallIns.ForEach(fallIn => fallIn.FallOut())));
    }

    IEnumerator WaitThen(Action cb)
    {
        yield return new WaitForSeconds(1);
        cb();
    }
}