using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LevelSelect : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public LevelData LevelData;
    public Animator Stars;
    private Levels Levels;
    private Level Level;
    private MenuController MenuController;

    private Sprite LockedSprite;
    private Button Button;
    private Image Image;
    private ButtonCursor ButtonCursor;

    void Awake()
    {
        LockedSprite = Resources.Load<Sprite>("Sprites/room-wireframe");
        MenuController = FindObjectOfType<MenuController>();
        Levels = FindObjectOfType<Levels>();

        Button = GetComponent<Button>();
        Image = GetComponent<Image>();
        ButtonCursor = GetComponent<ButtonCursor>();
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
            ButtonCursor.enabled = false;
        }
        else
        {
            Button.enabled = true;
            Image.sprite = LevelData.Preview;
            ButtonCursor.enabled = true;
        }
    }

    private void LoadScene()
    {
        SceneLoader.MaybeUnloadSceneAsync("Collectables");
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

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (!Level.Locked && Level.LowestInteractionScore != 0)
        {
            UpdateStars();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!Level.Locked && Level.LowestInteractionScore != 0)
        {
            CloseStars();
        }
    }
}