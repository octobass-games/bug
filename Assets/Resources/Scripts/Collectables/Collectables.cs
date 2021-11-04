using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public List<CollectableData> CollectableData;

    public List<Collectable> CollectableList = new List<Collectable>();
    public UnlockedCollectable UI;

    void Start()
    {
        CollectableData.ForEach((c) => CollectableList.Add(new Collectable(c)));
    }

    public void UnlockCollectable(CollectableData data)
    {
        var collecatable = CollectableList.Find(c => c.Data.Name == data.Name);
        if (collecatable == null)
        {
            Debug.Log("Could not find collectable: " + data.Name);
            return;
        }

        Debug.Log("collectable unlocked");
        UI.Render(data);
        collecatable.Locked = false;
    }
}