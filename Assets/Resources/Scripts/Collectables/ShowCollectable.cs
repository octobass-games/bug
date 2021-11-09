using UnityEngine;

[RequireComponent(typeof(Inspectable))]
public class ShowCollectable : MonoBehaviour
{
    public CollectableData CollectableData;

    void Awake()
    {
        var collectables = FindObjectOfType<Collectables>();
        GetComponent<Inspectable>().OnInspect.AddListener(() => collectables?.ShowCollectable(CollectableData));
    }
}
