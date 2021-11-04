using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnClick : MonoBehaviour
{
    public UnityEvent Event;

    public void Invoke() => Event.Invoke();
}