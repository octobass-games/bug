using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<LevelData> LevelData;

    public List<Level> LevelList = new List<Level>();

    void Start()
    {
        LevelData.ForEach((l) => LevelList.Add(new Level(l)));
    }

    public void UnlockLevel(CollectableData data)
    {
        var level = LevelList.Find(c => c.Data == data);
        if (level == null)
        {
            Debug.Log("Could not find level: " + data.Name);
            return;
        }
        level.Locked = false;
    }
}