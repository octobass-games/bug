using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class OnClick : MonoBehaviour
{
    public UnityEvent Event;

    public void Invoke()
    {
        Event.Invoke();
    }
}