using System.Linq;
using UnityEngine;

public class CollectableStand: MonoBehaviour
{
    public CollectableData CollectableData;
    private Collectables Collectables;
    private Collectable collectable;
    public SpriteRenderer Sprite;
    public SpriteRenderer StandSprite;

    void Start()
    {
        Collectables = FindObjectOfType<Collectables>();

        collectable = Collectables.Find(CollectableData);
        Sprite.sprite = CollectableData.sprite;

        bool itemActive = !collectable.Locked;

        foreach (Transform child in transform)
        {
            Debug.Log("child");
            child.gameObject.SetActive(itemActive);
        }

        if (itemActive)
        {
            StandSprite.color = CollectableData.Colour;
        }else
        {
            StandSprite.color = Color.white;
        }
    }

}