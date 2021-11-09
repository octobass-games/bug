using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

[RequireComponent(typeof(Collider2D))]
public class Inspectable : MonoBehaviour
{
    public bool OnlyFireOnce;
    [FormerlySerializedAs("Event")]
    public UnityEvent OnInspect;

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
            OnInspect.Invoke();
        }
        else if (OnlyFireOnce && !HasBeenTriggered)
        {
            OnInspect.Invoke();
            HasBeenTriggered = true;
        }
    }
}