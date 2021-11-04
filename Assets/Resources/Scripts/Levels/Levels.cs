using System.Collections.Generic;
using UnityEngine;

public class Levels : MonoBehaviour
{
    public List<LevelData> LevelData;

    public List<Level> LevelList = new List<Level>();

    public LevelSummary LevelSummary;

    void Start()
    {
        LevelData.ForEach((l) => LevelList.Add(new Level(l)));
    }

    public void CompleteLevel(LevelData data, int interactionCount)
    {
        var level = FindLevel(data);
        level.UpdateInteractionCount(interactionCount);
        var nextLevel = NextLevel(data);
        if (nextLevel != null)
        {
            nextLevel.Locked = false;
        }

        LevelSummary.ShowSummary(level, interactionCount, () => SceneLoader.LoadScene(nextLevel?.Data, data));
    }

    public void UnlockLevel(LevelData data)
    {
        var level = FindLevel(data);
        level.Locked = false;
    }

    private Level NextLevel(LevelData data)
    {
        var index = LevelList.FindIndex(l => l.Data == data);
        return LevelList[index + 1];
    }

    public Level FindLevel(LevelData data)
    {
        var level = LevelList.Find(l => l.Data == data);

        if (level == null)
        {
            Debug.Log("Could not find level: " + data.Name);
        }

        return level;
    }
}