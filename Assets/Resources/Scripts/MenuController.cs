using UnityEngine;

public enum Menu
{
    PAUSE,
    LEVEL_SELECT,
    COLLECTABLES
}

public class MenuController : MonoBehaviour
{
    public GameObject LevelSelectPanel;
    public GameObject PausePanel;
    public GameObject CollectablesPanel;

    public MusicLoader musicLoader;
    public string toggleMenuSFX;

    public void OpenLevelSelect() => OpenMenu(Menu.LEVEL_SELECT);

    public void OpenCollectables() => OpenMenu(Menu.COLLECTABLES);

   

    public void OpenPause()
    {
        OpenMenu(Menu.PAUSE);
    }
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
        CollectablesPanel.SetActive(menu == Menu.COLLECTABLES);
        musicLoader.SetMenuMusic(true);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenu()
    {
        LevelSelectPanel.SetActive(false);
        PausePanel.SetActive(false);
        CollectablesPanel.SetActive(false);
        Time.timeScale = 1;
        musicLoader.SetMenuMusic(false);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

}