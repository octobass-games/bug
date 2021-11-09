using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public class Inspectable : MonoBehaviour
{
    public bool OnlyFireOnce;
    public bool Disabled = false;
    public bool ShouldEnlargeOnHover = true;
    public UnityEvent OnInspect;

    private bool HasBeenTriggered;

    void Awake()
    {
        if (ShouldEnlargeOnHover)
        {
            gameObject.MaybeAddComponent<EnlargeOnHover>();
        }    
    }

    public void Invoke()
    {
        if (Disabled)
        {
            return;
        }

        if (!OnlyFireOnce)
        {
            OnInspect.Invoke();
        }
        else if (OnlyFireOnce && !HasBeenTriggered)
        {
            OnInspect.Invoke();
            HasBeenTriggered = true;
        }
    }
}