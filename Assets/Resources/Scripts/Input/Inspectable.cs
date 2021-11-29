using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Collider2D))]
public class Inspectable : MonoBehaviour
{
    public bool OnlyFireOnce;
    public bool Disabled = false;
    public bool ShouldEnlargeOnHover = true;
    public UnityEvent OnInspect;
    public CustomCursor CustomCursor;
    public bool IncrementInteractionCount = true;

    private bool HasBeenTriggered;
    private LevelTracker LevelTracker;

    void Awake()
    {
        CustomCursor = FindObjectOfType<CustomCursor>();
        LevelTracker = FindObjectOfType<LevelTracker>();

        if (IncrementInteractionCount)
        {
            OnInspect.AddListener(() => LevelTracker?.IncrementInteractionCount());
        }

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