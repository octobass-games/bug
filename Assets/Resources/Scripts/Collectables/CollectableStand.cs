using System.Linq;
using UnityEngine;

public class CollectableStand: MonoBehaviour
{
    public CollectableData CollectableData;
    private Collectables Collectables;
    private Collectable collectable;
    public SpriteRenderer Sprite;

    void Start()
    {
        Collectables = FindObjectOfType<Collectables>();
        var standSprite = GetComponent<SpriteRenderer>();

        collectable = Collectables.Find(CollectableData);
        Sprite.sprite = CollectableData.sprite;

        bool itemActive = !collectable.Locked;

        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(itemActive);
        }

        GetComponent<OnClick>().disabled = !itemActive;

        if (itemActive)
        {
            standSprite.color = CollectableData.Colour;
        }else
        {
            standSprite.color = Color.white;
        }
    }

}