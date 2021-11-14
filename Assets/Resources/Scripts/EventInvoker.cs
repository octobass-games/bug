using UnityEngine;
using UnityEngine.Events;

public class EventInvoker: MonoBehaviour
{
    public UnityEvent Event;
    public UnityEvent Event2;
    public UnityEvent Event3;

    public void InvokeCustomEvent() => Event.Invoke();
    public void InvokeCustomEvent2() => Event2.Invoke();
    public void InvokeCustomEvent3() => Event3.Invoke();
}