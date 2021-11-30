using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Inspectable))]
public class UnlockCollectableOnClick : MonoBehaviour
{
    public CollectableData CollectableData;

    void Awake()
    {
        var collectables = FindObjectOfType<Collectables>();

        GetComponent<Inspectable>().OnInspect.AddListener(Unlock);

        var collectable = collectables?.CollectableList.Find(collectable => collectable.Name == CollectableData.Name);

        if (collectable !=null && !collectable.Locked)
        {
            var spriteRenderer = GetComponent<SpriteRenderer>();
            spriteRenderer.SetOpacity(0.5f);
        }
    }

    private void Unlock()
    {
        FindObjectOfType<Collectables>().UnlockCollectable(CollectableData);
        gameObject.SetActive(false);
    }
}
