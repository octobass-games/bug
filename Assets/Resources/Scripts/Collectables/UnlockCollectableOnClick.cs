using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Inspectable))]
public class UnlockCollectableOnClick : MonoBehaviour
{
    public CollectableData CollectableData;

    void Awake()
    {
        var collectables = FindObjectOfType<Collectables>();

        GetComponent<Inspectable>().OnInspect.AddListener(() => {
            collectables?.UnlockCollectable(CollectableData);
            gameObject.SetActive(false);
        });
    }
}
