using UnityEngine;
using UnityEngine.Events;

public class EventInvoker: MonoBehaviour
{
    public UnityEvent Event;

    public void InvokeCustomEvent()
    {
        Event.Invoke();
    }
}