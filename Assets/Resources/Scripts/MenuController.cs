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


    public void OpenMenu(Menu menu)
    {
        LevelSelectPanel.SetActive(menu == Menu.LEVEL_SELECT);
        PausePanel.SetActive(menu == Menu.PAUSE);
        CollectablesPanel.SetActive(menu == Menu.COLLECTABLES);
    }

    public void CloseMenu()
    {
        LevelSelectPanel.SetActive(false);
        PausePanel.SetActive(false);
        CollectablesPanel.SetActive(false);
    }

}