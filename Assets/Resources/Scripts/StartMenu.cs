using System.Collections;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private MenuController MenuController;
    private Saver Saver;
    public GameObject CollectablesButton;
    public GameObject ContinueButton;

    IEnumerator Start()
    {
        while (!FMODUnity.RuntimeManager.HasBankLoaded("Music"))
        {
            yield return null;
        }

        SceneLoader.MaybeLoadScene("Brain");

        var hasSaveData = Saver.HasSaveData();

        ContinueButton.SetActive(hasSaveData);
        CollectablesButton.SetActive(hasSaveData);
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

    public void Collectables()
    {
        FindSaver().Load();
        SceneLoader.SwitchScene("StartMenu", "Collectables");
    }

    public void Credits()
    {
        SceneLoader.SwitchScene("StartMenu", "Credits");
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
