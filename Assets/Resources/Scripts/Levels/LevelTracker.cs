using UnityEngine;

public class LevelTracker : MonoBehaviour
{
    public LevelData Level;

    private int InteractionCount;

    public void CompleteLevel() => FindObjectOfType<Levels>().CompleteLevel(Level, InteractionCount);

    public void IncrementInteractionCount() => InteractionCount += 1;
}
