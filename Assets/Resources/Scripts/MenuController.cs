using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
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

    private Stack<GameObject> Panels = new Stack<GameObject>();


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
        Panels.Clear();
        OpenMenu(Menu.PAUSE);
    }

    public void OpenControls() => OpenMenu(Menu.CONTROLS);

    public void TogglePause(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (Panels.Count == 0)
            {
                OpenPause();
            }
            else
            {
                CloseMenus();
            }
        }
    }

    public void OpenMenu(Menu menu)
    {
        Time.timeScale = 0;

        if (Panels.Count() > 0)
        {
            Panels.Peek().SetActive(false);
        }

        switch (menu)
        {
            case Menu.CONTROLS:
                Panels.Push(ControlsPanel);
                break;
            case Menu.LEVEL_SELECT:
                Panels.Push(LevelSelectPanel);
                break;
            case Menu.PAUSE:
                Panels.Push(PausePanel);
                break;
        }

        Panels.Peek().SetActive(true);

        musicLoader.SetMenuMusic(true);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;

        var currentPanel = Panels.Pop();

        if (Panels.Count == 0 && currentPanel == PausePanel)
        {
            currentPanel.SetActive(false);
        }
        else if (Panels.Count > 0)
        {
            currentPanel.SetActive(false);
            Panels.Peek().SetActive(true);
        }
        else
        {
            currentPanel.SetActive(false);
            SceneManager.LoadScene("StartMenu", LoadSceneMode.Additive);
        }

        musicLoader.SetMenuMusic(false);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenus()
    {
        Time.timeScale = 1;

        while (Panels.Count > 0)
        {
            Panels.Pop().SetActive(false);
        }

        musicLoader.SetMenuMusic(false);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }
}