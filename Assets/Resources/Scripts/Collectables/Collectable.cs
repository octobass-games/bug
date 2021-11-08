using UnityEngine;

[System.Serializable]
public class Collectable
{
    public CollectableData Data;
    public bool Locked = true;
    public string Name;

    public Collectable(CollectableData data, bool locked = true)
    {
        Data = data;
        Locked = locked;
        Name = data.Name;
    }
}