using UnityEngine;

[RequireComponent(typeof(Inspectable))]
public class Pickupable : MonoBehaviour
{
    void Awake()
    {
        var inventory = FindObjectOfType<Inventory>();
        var fall = GetComponent<Fall>();

        var inspectable = GetComponent<Inspectable>();

        inspectable.OnInspect.AddListener(() => inventory.Add(gameObject));
        inspectable.OnInspect.AddListener(() => fall.enabled = false);
        inspectable.OnlyFireOnce = true;
    }
}