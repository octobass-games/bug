using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour, ILoadable
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


    public void ShowCollectable(CollectableData data)
    {
        var collecatable = CollectableList.Find(c => c.Data.Name == data.Name);
        if (collecatable == null)
        {
            Debug.Log("Could not find collectable: " + data.Name);
            return;
        }

        UI.RenderAlreadyUnlocked(data);
    }


    public Collectable Find(CollectableData data)
    {
        var collecatable = CollectableList.Find(c => c.Data.Name == data.Name);
        if (collecatable == null)
        {
            Debug.Log("Could not find collectable: " + data.Name);
        }
        return collecatable;
    }

    public void OnLoad(SaveData saveData)
    {
        var collectables = saveData.Collectables;

        collectables.ForEach(collectable =>
        {
            var collectableData = CollectableData.Find(collectableData => collectableData.Name == collectable.Name);

            collectable.Data = collectableData;
        });

        CollectableList = collectables;
    }
}