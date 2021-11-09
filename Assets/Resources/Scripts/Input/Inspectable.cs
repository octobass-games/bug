using UnityEngine;
using UnityEngine.Events;

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

    public void Inspect()
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