using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Levels : MonoBehaviour, ILoadable
{
    public List<Level> LevelList = new List<Level>();
    public List<LevelData> LevelData;
    public LevelSummary LevelSummary;
    public Level CurrentLevel;
    public Scene CurrentLevelScene;

    void Awake()
    {
        Init();
    }

    public void CompleteLevel(LevelData data, int interactionCount)
    {
        var level = FindLevel(data);
        level.UpdateInteractionCount(interactionCount);
        var nextLevel = NextLevel(data);
        if (nextLevel != null)
        {
            nextLevel.Locked = false;
            LevelSummary.ShowSummary(level, interactionCount, () => {
                FindObjectOfType<Saver>()?.Save();
                SceneLoader.SwitchScene(data, nextLevel?.Data);
            });
        }
        else
        {
            LevelSummary.ShowSummaryAsEndLevel(level, interactionCount, () =>
            {
                SceneLoader.SwitchScene(data, "Credits");

            });
        }
    }

    public void NextLevel()
    {
        if (CurrentLevel == null)
        {
            return;
        }
        var nextLevel = NextLevel(CurrentLevel.Data);
        nextLevel.Locked = false;
        FindObjectOfType<Saver>()?.Save();
        SceneLoader.SwitchScene(CurrentLevel.Data, nextLevel?.Data);
    }

    public void UnlockLevel(LevelData data)
    {
        var level = FindLevel(data);
        level.Locked = false;
    }

    private Level NextLevel(LevelData data)
    {
        var index = LevelList.FindIndex(l => l.Data == data);

        if (index >= LevelList.Count -1)
        {
            return null;
        }
        return LevelList[index + 1];
    }

    public Level FindLevel(LevelData data) => FindLevel(data.SceneName);

    public Level FindLevel(string sceneName)
    {
        var level = LevelList.Find(l => l.Data.SceneName == sceneName);

        if (level == null)
        {
            Debug.Log("Could not find level: " + sceneName);
        }

        return level;
    }

    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private List<string> NonLevelScenes = new List<string>(){"Brain", "StartMenu", "Collectables" };

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (!NonLevelScenes.Contains(scene.name))
        {
            var level = FindLevel(scene.name);
            CurrentLevel = level;
            CurrentLevelScene = scene;
        }
    }

    public void OnLoad(SaveData saveData)
    {
        var levels = saveData.Levels;

        levels.ForEach(level =>
        {
            LevelData levelData = LevelData.Find(levelData => levelData.Name == level.Name);
            level.Data = levelData;
        });

        LevelList = levels;
    }

    public void OnDelete()
    {
        Init();
    }

    private void Init()
    {
        LevelList.Clear();
        LevelData.ForEach((l) => LevelList.Add(new Level(l)));
        LevelList[0].Locked = false;
    }
}