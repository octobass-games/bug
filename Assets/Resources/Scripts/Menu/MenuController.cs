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

    private Stack<GameObject> Panels = new Stack<GameObject>();

    public void OpenCollectables()
    {
        HideMenus();
        MusicEmitter.SetParameter("isPaused", 1f);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
        SceneManager.LoadScene("Collectables", LoadSceneMode.Additive);
        Levels.CurrentLevelScene.GetRootGameObjects().ToList().ForEach(g => g.SetActive(false));
    }

    public void CloseCollectables()
    {
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
        MusicEmitter.SetParameter("isPaused", 0f);
        SceneManager.UnloadSceneAsync("Collectables");
        Levels.CurrentLevelScene.GetRootGameObjects().ToList().ForEach(g => g.SetActive(true));
    }
    public void TogglePause(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            if (!SceneManager.GetSceneByName("StartMenu").isLoaded)
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
    }

    public void OpenControls() => OpenMenu(Menu.CONTROLS);

    public void OpenLevelSelect() => OpenMenu(Menu.LEVEL_SELECT);

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

        MusicEmitter.SetParameter("isPaused", 1f);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenu()
    {
        Time.timeScale = 1;

        var currentPanel = Panels.Pop();

        if (Panels.Count == 0 && currentPanel == PausePanel)
        {
            currentPanel.SetActive(false);
            MusicEmitter.SetParameter("isPaused", 0f);
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
            MusicEmitter.SetParameter("isPaused", 0f);
        }

        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    public void CloseMenus()
    {
        Time.timeScale = 1;

        while (Panels.Count > 0)
        {
            Panels.Pop().SetActive(false);
        }

        MusicEmitter.SetParameter("isPaused", 0f);
        FMODUnity.RuntimeManager.PlayOneShot(toggleMenuSFX);
    }

    private void HideMenus()
    {
        Time.timeScale = 1;
        Panels.ToList().ForEach(panel => panel.SetActive(false));
    }

    private void OpenPause() => OpenMenu(Menu.PAUSE);
}