using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class OnClick : MonoBehaviour
{
    public bool OnlyFireOnce;
    public UnityEvent Event;

    private bool HasBeenTriggered;
    public bool disabled = false;
    public bool ShouldEnlargeOnHover = true;

    void Awake()
    {
        if (ShouldEnlargeOnHover)
        {
            gameObject.MaybeAddComponent<EnlargeOnHover>();
        }    
    }

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