using UnityEngine;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour
{

    public LevelData LevelData;
    public Animator Stars;
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
        SceneLoader.MaybeUnloadScene("Collectables");
        SceneLoader.SwitchScene(Levels.CurrentLevel.Data, LevelData);
        MenuController.CloseMenus();
    }

    public void UpdateStars()
    {
        Stars.gameObject.SetActive(true);
        Stars.SetInteger("Stars", Level.GetStarRating(Level.LowestInteractionScore));
        Stars.SetTrigger("Start");
    }

    public void CloseStars()
    {
        Stars.SetTrigger("End");
        Stars.gameObject.SetActive(false);
    }
}