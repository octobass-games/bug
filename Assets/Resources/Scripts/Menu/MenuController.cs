using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public FMODUnity.StudioEventEmitter MusicEmitter;
    public GameObject LevelSelectPanel;
    public GameObject PausePanel;
    public GameObject ControlsPanel;
    public string toggleMenuSFX;
    public Levels Levels;

    private Stack<GameObject> MenuHistory = new Stack<GameObject>();

    public void OpenCollectables()
    {
        HideMenus();
        MusicEmitter.SetParameter("isPaused", 1f);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
        SceneManager.LoadScene("Collectables", LoadSceneMode.Additive);

        if (Levels.CurrentLevelScene.IsValid())
        {
            Levels.CurrentLevelScene.GetRootGameObjects().ToList().ForEach(g => g.SetActive(false));
        }
    }

    public void CloseCollectables()
    {
        GoBackInMenus();
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
        MusicEmitter.SetParameter("isPaused", 0f);
        var unload = SceneManager.UnloadSceneAsync("Collectables");

        unload.completed += action =>
        {
            if (SceneManager.sceneCount == 1)
            {
                SceneLoader.MaybeLoadScene("StartMenu");
            }
        };

        if (Levels.CurrentLevelScene.IsValid())
        {
            Levels.CurrentLevelScene.GetRootGameObjects().ToList().ForEach(g => g.SetActive(true));
        }
    }
    public void TogglePause(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!SceneManager.GetSceneByName("StartMenu").isLoaded && !SceneManager.GetSceneByName("Collectables").isLoaded)
            {
                if (MenuHistory.Count == 0)
                {
                    OpenPause();
                }
                else
                {
                    GoBackInMenus();
                }
            }
        }
    }

    public void OpenControls() => OpenMenu(Menu.CONTROLS);

    public void OpenLevelSelect() => OpenMenu(Menu.LEVEL_SELECT);

    public void OpenMenu(Menu menu)
    {
        Time.timeScale = 0;

        if (MenuHistory.Count() > 0)
        {
            MenuHistory.Peek().SetActive(false);
        }

        switch (menu)
        {
            case Menu.CONTROLS:
                MenuHistory.Push(ControlsPanel);
                break;
            case Menu.LEVEL_SELECT:
                MenuHistory.Push(LevelSelectPanel);
                break;
            case Menu.PAUSE:
                MenuHistory.Push(PausePanel);
                break;
        }

        MenuHistory.Peek().SetActive(true);

        MusicEmitter.SetParameter("isPaused", 1f);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;

        var currentPanel = MenuHistory.Pop();

        if (MenuHistory.Count == 0 && currentPanel == PausePanel)
        {
            currentPanel.SetActive(false);
            MusicEmitter.SetParameter("isPaused", 0f);
        }
        else if (MenuHistory.Count > 0)
        {
            currentPanel.SetActive(false);
            MenuHistory.Peek().SetActive(true);
        }
        else
        {
            currentPanel.SetActive(false);
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Additive);
            MusicEmitter.SetParameter("isPaused", 0f);
        }

        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void GoBackInMenus()
    {
        Time.timeScale = 1;

        while (MenuHistory.Count > 0)
        {
            if (MenuHistory.Count == 1 && MenuHistory.Peek() != PausePanel)
            {
                SceneManager.LoadScene("StartMenu", LoadSceneMode.Additive);
            }

            var menu = MenuHistory.Pop();
            menu.SetActive(false);
        }

        MusicEmitter.SetParameter("isPaused", 0f);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenus()
    {
        Time.timeScale = 1;

        while (MenuHistory.Count > 0)
        {
            MenuHistory.Pop().SetActive(false);
        }

        MusicEmitter.SetParameter("isPaused", 0f);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void MainMenu()
    {
        CloseMenus();
        SceneLoader.CloseAllScenesExcept("Brain");
        SceneLoader.MaybeLoadScene("StartMenu");
        Levels.CurrentLevel = null;
    }

    private void HideMenus()
    {
        Time.timeScale = 1;
        MenuHistory.ToList().ForEach(panel => panel.SetActive(false));
    }

    public void SkipLevel()
    {
        Levels.NextLevel();
        CloseMenus();
    }

    private void OpenPause() => OpenMenu(Menu.PAUSE);
}