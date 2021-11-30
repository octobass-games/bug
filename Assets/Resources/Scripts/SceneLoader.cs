﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void UnloadSceneAsync(string scene, Action<AsyncOperation> onCompleted)
    {
        var unload = SceneManager.UnloadSceneAsync(scene);

        unload.completed += onCompleted;
    }

    public static void SwitchScene(LevelData currentLevel, LevelData newLevel)
    {
        if (currentLevel)
        {
            SwitchScene(currentLevel.SceneName, newLevel.SceneName);
        }
        else
        {
            SceneManager.LoadScene(newLevel.SceneName, LoadSceneMode.Additive);
        }
    }

    
    public static void SwitchScene(LevelData currentLevel, string newLevel)
    {
        if (currentLevel)
        {
            SwitchScene(currentLevel.SceneName, newLevel);
        }
        else
        {
            SceneManager.LoadScene(newLevel, LoadSceneMode.Additive);
        }
    }

    public static void SwitchScene(string currentScene, string newScene) =>
        UnloadSceneAsync(currentScene, action => SceneManager.LoadScene(newScene, LoadSceneMode.Additive));

    public static void MaybeLoadScene(string scene)
    {
        if (!SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.LoadScene(scene, LoadSceneMode.Additive);
        }
    }

    public static void MaybeUnloadScene(string scene)
    {
        if (SceneManager.GetSceneByName(scene).isLoaded)
        {
            SceneManager.UnloadSceneAsync(scene);
        }
    }

    public static void CloseAllScenesExcept(string scene)
    {
        var sceneCount = SceneManager.sceneCount;

        for (int i = 0; i < sceneCount; ++i)
        {
            var sceneName = SceneManager.GetSceneAt(i).name;

            if (sceneName != scene)
            {
                SceneManager.UnloadSceneAsync(sceneName);
            }
        }
    }
}