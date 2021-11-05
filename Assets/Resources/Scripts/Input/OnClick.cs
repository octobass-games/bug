using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(EnlargeOnHover))]
public class OnClick : MonoBehaviour
{
    public bool OnlyFireOnce;
    public UnityEvent Event;

    private bool HasBeenTriggered;

    public void Invoke()
    {
        if (!OnlyFireOnce)
        {
            Event.Invoke();
        }
        else if (OnlyFireOnce && !HasBeenTriggered)
        {
            Event.Invoke();
            HasBeenTriggered = true;
        }
    }
}