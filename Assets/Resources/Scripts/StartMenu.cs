using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour
{
    void Awake()
    {
        SceneManager.LoadScene("Menus", LoadSceneMode.Additive);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Level1");
        SceneManager.LoadScene("Menus", LoadSceneMode.Additive);
    }

    public void LevelSelect()
    {

    }
}
