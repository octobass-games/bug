using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnClick : MonoBehaviour
{
    public UnityEvent Event;
    public bool IsTrigger;

    private bool HasBeenTriggered;

    public void Invoke()
    {
        if (!IsTrigger)
        {
            Event.Invoke();
        }
        else if (IsTrigger && !HasBeenTriggered)
        {
            Event.Invoke();
            HasBeenTriggered = true;
        }
    }
}