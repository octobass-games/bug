using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelSummary : MonoBehaviour
{
    public GameObject Panel;
    public Image Image;
    public Animator StarAnimator;
    public Button NextLevelButton;

   
    public void ShowSummary(Level level, int interactions, UnityAction GoToNextLevel)
    {
        Panel.SetActive(true);
        Image.sprite = level.Data.Sprite;
        StarAnimator.SetInteger("Stars", level.GetStarRating(interactions));
        NextLevelButton.onClick.AddListener(GoToNextLevel);
        NextLevelButton.onClick.AddListener(() => Panel.SetActive(false));
    }

}