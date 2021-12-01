using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelSummary : MonoBehaviour
{
    public GameObject Panel;
    public Image Image;
    public Animator StarAnimator;
    public Button NextLevelButton;
    public Button CreditsButton;
    public GameObject FallingSpritePrefab;
    public List<GameObject> FallingSpriteContainers;
    public Image LevelCompleteImage;

    public void ShowSummary(Level level, int interactionCount, UnityAction GoToNextLevel)
    {
        CreditsButton.gameObject.SetActive(false);
        Panel.SetActive(true);
        LevelCompleteImage.sprite = level.Data.LevelCompleteSprite;
        Image.sprite = level.Data.Sprite;
        StarAnimator.SetInteger("Stars", level.GetStarRating(interactionCount));
        NextLevelButton.onClick.RemoveAllListeners();
        NextLevelButton.onClick.AddListener(GoToNextLevel);
        NextLevelButton.onClick.AddListener(() => Panel.SetActive(false));
        FallingItems(level);
    }

    public void ShowSummaryAsEndLevel(Level level, int interactionCount, UnityAction GoToCredits)
    {
        NextLevelButton.gameObject.SetActive(false);
        Panel.SetActive(true);
        LevelCompleteImage.sprite = level.Data.LevelCompleteSprite;
        Image.sprite = level.Data.Sprite;
        StarAnimator.SetInteger("Stars", level.GetStarRating(interactionCount));
        CreditsButton.gameObject.SetActive(true);
        CreditsButton.onClick.RemoveAllListeners();
        CreditsButton.onClick.AddListener(GoToCredits);
        CreditsButton.onClick.AddListener(() => Panel.SetActive(false));

        FallingItems(level);
    }

    private void FallingItems(Level level)
    {
        FallingSpriteContainers.ForEach(gameObject =>
        {
            gameObject.DestroyChildren();
            gameObject.GetComponent<MenuFallInOnEnabled>().Offset = level.Data.FallingSprites.Count * 200;
            level.Data.FallingSprites.Shuffle().ToList().ForEach(s =>
            {
                GameObject fallingObject = Instantiate(FallingSpritePrefab);
                var image = fallingObject.GetComponent<Image>();
                image.sprite = s;
                image.enabled = true;
                fallingObject.transform.SetParent(gameObject.transform);
            });
        });
    }
}