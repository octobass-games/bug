using UnityEngine;

public class Level : MonoBehaviour
{
    public LevelData Data;
    public bool Locked = true;

    public Level(LevelData data, bool locked = true)
    {
        Data = data;
        Locked = locked;
    }
}