using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Menu
{
    PAUSE,
    LEVEL_SELECT,
    CONTROLS
}

public class MenuController : MonoBehaviour
{
    public GameObject LevelSelectPanel;
    public GameObject PausePanel;
    public GameObject ControlsPanel;

    public MusicLoader musicLoader;
    public string toggleMenuSFX;
    public Levels Levels;

    public void OpenLevelSelect() => OpenMenu(Menu.LEVEL_SELECT);

    public void OpenCollectables()
    {
        CloseMenu();

        musicLoader.SetMenuMusic(true);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
        SceneManager.LoadScene("Collectables", LoadSceneMode.Additive);
        Levels.CurrentLevelScene.GetRootGameObjects().ToList().ForEach(g => g.SetActive(false));
    }

    public void CloseCollectables()
    {
        CloseMenu();
        musicLoader.SetMenuMusic(false);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
        SceneManager.UnloadSceneAsync("Collectables");
        Levels.CurrentLevelScene.GetRootGameObjects().ToList().ForEach(g => g.SetActive(true));
    }


    public void OpenPause()
    {
        OpenMenu(Menu.PAUSE);
    }

    public void OpenControls() => OpenMenu(Menu.CONTROLS);
   
    public void TogglePause()
    {
        if (!PausePanel.activeSelf)
        {
            OpenPause();
        }
        else
        {
            CloseMenu();
        }
    }

    public void OpenMenu(Menu menu)
    {
        Time.timeScale = 0;
        LevelSelectPanel.SetActive(menu == Menu.LEVEL_SELECT);
        PausePanel.SetActive(menu == Menu.PAUSE);
        ControlsPanel.SetActive(menu == Menu.CONTROLS);
        musicLoader.SetMenuMusic(true);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenu()
    {
        LevelSelectPanel.SetActive(false);
        PausePanel.SetActive(false);
        ControlsPanel.SetActive(false);
        Time.timeScale = 1;
        musicLoader.SetMenuMusic(false);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

}