using UnityEngine.SceneManagement;

public static class SceneLoader
{
    public static void LoadScene(LevelData level)
    {
        SceneManager.LoadScene(level.SceneName);
        SceneManager.LoadScene("Brain", LoadSceneMode.Additive);
    }
}