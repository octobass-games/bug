using UnityEngine;

public class CompleteLevel : MonoBehaviour
{
    public LevelData Level;

    void Complete()
    {
        Levels levels = FindObjectOfType<Levels>();
        levels.CompleteLevel(Level, 1);
    }
}