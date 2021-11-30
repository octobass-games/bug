using System;
using System.Collections;
using System.Linq;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject Camera;
    public bool IsInitialRoom;

    private Coroutine FallingOutCoroutine;

    void Awake()
    {
        if (!IsInitialRoom)
        {
            gameObject.SetActive(false);
        }
    }

    public void FallIn()
    {
        if (FallingOutCoroutine != null)
        {
            StopCoroutine(FallingOutCoroutine);
        }

        var fallIns = GetComponentsInChildren<Fall>().ToList();

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