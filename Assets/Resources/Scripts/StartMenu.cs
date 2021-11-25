using System.Collections;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private MenuController MenuController;
    private Saver Saver;

    IEnumerator Start()
    {
        while (!FMODUnity.RuntimeManager.HasBankLoaded("Music"))
        {
            yield return null;
        }

        SceneLoader.MaybeLoadScene("Brain");
    }

    public void StartGame()
    {
        SceneLoader.SwitchScene("StartMenu", "Level1");
    }

    public void LoadGame()
    {
        FindSaver().Load();
        LevelSelect();
    }

    public void LevelSelect() =>
        SceneLoader.UnloadSceneAsync("StartMenu", action => FindMenuController().OpenMenu(Menu.LEVEL_SELECT));

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
