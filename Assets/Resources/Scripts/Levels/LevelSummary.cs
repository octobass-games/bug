using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelSummary : MonoBehaviour
{
    public GameObject Panel;
    public Image Image;
    public Animator StarAnimator;
    public Button NextLevelButton;
    public GameObject FallingSpritePrefab;
    public List<GameObject> FallingSpriteContainers;

    public void ShowSummary(Level level, int interactionCount, UnityAction GoToNextLevel)
    {
        Panel.SetActive(true);

        Image.sprite = level.Data.Sprite;
        StarAnimator.SetInteger("Stars", level.GetStarRating(interactionCount));
        NextLevelButton.onClick.AddListener(GoToNextLevel);
        NextLevelButton.onClick.AddListener(() => Panel.SetActive(false));
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