using UnityEngine;

public class Collectable
{
    public CollectableData Data;
    public bool Locked = true;

    public Collectable(CollectableData data, bool locked = true)
    {
        Data = data;
        Locked = locked;
    }
}