using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    private MenuController MenuController;
    private Saver Saver;

    void Awake()
    {
        if (!SceneManager.GetSceneByName("Brain").isLoaded)
        {
            SceneManager.LoadScene("Brain", LoadSceneMode.Additive);
        }
    }

    public void StartGame()
    {
        SceneManager.UnloadSceneAsync("StartMenu");
        SceneManager.LoadScene("Level1", LoadSceneMode.Additive);
    }

    public void LoadGame()
    {
        FindSaver().Load();
        LevelSelect();
    }

    public void LevelSelect()
    {
        SceneManager.UnloadSceneAsync("StartMenu");
        FindMenuController().OpenMenu(Menu.LEVEL_SELECT);
    }

    private MenuController FindMenuController()
    {
        if (MenuController == null)
        {
            MenuController = FindObjectOfType<MenuController>();
        }

        return MenuController;
    }

    private Saver FindSaver()
    {
        if (Saver == null)
        {
            Saver = FindObjectOfType<Saver>();
        }

        return Saver;
    }
}
