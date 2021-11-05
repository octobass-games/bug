using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    private bool IsDragging;
    private Collider2D[] OverlappingColliders = new Collider2D[1];
    private ContactFilter2D ContactFilter = new ContactFilter2D
    {
        useTriggers = true
    };

    void Update()
    {
        if (IsDragging)
        {
            var mouseWorldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, transform.position.z);
        }
    }

    public void DragStart() => IsDragging = true;

    public void DragEnd()
    {
        IsDragging = false;

        if (GetComponent<BoxCollider2D>().OverlapCollider(ContactFilter, OverlappingColliders) > 0)
        {
            OverlappingColliders[0].gameObject.GetComponent<Combinable>()?.Combine(gameObject);
        }
    }
}
