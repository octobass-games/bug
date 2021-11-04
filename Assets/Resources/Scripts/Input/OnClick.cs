using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnClick : MonoBehaviour
{
    public UnityEvent Event;
    public bool OnlyFireOnce;

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