using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnClick : MonoBehaviour
{
    public UnityEvent Event;
    public bool OnlyFireOnce;

    private bool HasBeenTriggered;
    public bool disabled = false;

    public void Invoke()
    {
        if (disabled)
        {
            return;
        }

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