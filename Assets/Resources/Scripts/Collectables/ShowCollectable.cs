using UnityEngine;

[RequireComponent(typeof(OnClick))]
public class ShowCollectable : MonoBehaviour
{
    public CollectableData CollectableData;

    void Awake()
    {
        var collectables = FindObjectOfType<Collectables>();
        GetComponent<OnClick>().Event.AddListener(() => collectables?.ShowCollectable(CollectableData));
    }
}
