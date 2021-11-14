using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(LevelData level, LevelData OldLevel)
    {
        Debug.Log("load level: " + level);
        Debug.Log("Unload level: " + OldLevel);
        if (OldLevel)
        {
            SceneManager.UnloadSceneAsync(OldLevel.SceneName);
        }

        SceneManager.LoadScene(level.SceneName, LoadSceneMode.Additive);
    }
}