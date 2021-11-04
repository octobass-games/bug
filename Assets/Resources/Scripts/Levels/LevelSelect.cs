using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public LevelData LevelData;
    private Levels Levels;
    private Level Level;
    private MenuController MenuController;

    private Sprite LockedSprite;
    private Button Button;
    private Image Image;

    void Awake()
    {
        LockedSprite = Resources.Load<Sprite>("Sprites/room-wireframe");
        MenuController = FindObjectOfType<MenuController>();
        Levels = FindObjectOfType<Levels>();

        Button = GetComponent<Button>();
        Image = GetComponent<Image>();
        Button.onClick.AddListener(this.LoadScene);
        Image.alphaHitTestMinimumThreshold = 0.1f;

    }

    // Use this for initialization
    void OnEnable()
    {
        Level = Levels.FindLevel(LevelData);

        if (Level.Locked)
        {
            Button.enabled = false;
            Image.sprite = LockedSprite;
        }else
        {
            Button.enabled = true;
            Image.sprite = LevelData.Preview;
        }
    }

    private void LoadScene()
    {
        SceneLoader.LoadScene(LevelData, Levels.CurrentLevel.Data);
        MenuController.CloseMenu();
    }
}