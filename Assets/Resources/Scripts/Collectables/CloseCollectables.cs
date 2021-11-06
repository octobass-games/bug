using UnityEngine;

public class CloseCollectables : MonoBehaviour
{
    private MenuController MenuController;

    void Start()
    {
        MenuController = FindObjectOfType<MenuController>();
    }

    public void Close() => MenuController.CloseCollectables();
}