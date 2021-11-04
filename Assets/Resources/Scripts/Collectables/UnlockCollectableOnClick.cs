using System.Collections;
using UnityEngine;

[RequireComponent(typeof(OnClick))]
public class UnlockCollectableOnClick : MonoBehaviour
{
    public CollectableData CollectableData;

    void Awake()
    {
        var collectables = FindObjectOfType<Collectables>();

        GetComponent<OnClick>().Event.AddListener(() => {
            collectables?.UnlockCollectable(CollectableData);
            gameObject.SetActive(false);
        });
    }
}
