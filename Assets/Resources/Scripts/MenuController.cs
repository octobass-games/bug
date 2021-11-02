using UnityEngine;

public enum Menu
{
    PAUSE,
    LEVEL_SELECT
}

public class MenuController : MonoBehaviour
{
    public GameObject LevelSelectPanel;
    public GameObject PausePanel;


    public void OpenMenu(Menu menu)
    {
        LevelSelectPanel.SetActive(menu == Menu.LEVEL_SELECT);
        PausePanel.SetActive(menu == Menu.PAUSE);
    }

    public void CloseMenu()
    {
        LevelSelectPanel.SetActive(false);
        PausePanel.SetActive(false);
    }

}