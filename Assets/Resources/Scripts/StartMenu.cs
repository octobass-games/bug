using System.Collections;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    private MenuController MenuController;
    private Saver Saver;
    public GameObject CollectablesButton;
    public GameObject ContinueButton;

    public PlaySoundEveryNSeconds Sleep;

    void Awake()
    {
        var hasSaveData = Saver.HasSaveData();

        ContinueButton.SetActive(hasSaveData);
        CollectablesButton.SetActive(hasSaveData);
    }

    IEnumerator Start()
    {
        while (!FMODUnity.RuntimeManager.HasBankLoaded("Music") || !FMODUnity.RuntimeManager.HasBankLoaded("SFX"))
        {
            yield return null;
        }

        SceneLoader.MaybeLoadScene("Brain");

        Sleep.enabled = true;
    }

    public void StartGame()
    {
        FindSaver()?.DeleteSaveData();
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

    public void Controls() =>
        SceneLoader.UnloadSceneAsync("StartMenu", action => FindMenuController().OpenMenu(Menu.CONTROLS));


    public void Credits()
    {
        SceneLoader.SwitchScene("StartMenu", "Credits");
    }

    public void Quit()
    {
        Application.Quit();
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
