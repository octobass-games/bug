using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    private bool isDragging;

    void Update()
    {
        if (isDragging)
        {
            var mouseWorldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, transform.position.z);
        }
    }

    public void DragStart() => isDragging = true;

    public void DragEnd()
    {
        isDragging = false;

        var results = new Collider2D[1];
        var contactFilter = new ContactFilter2D();
        contactFilter.useTriggers = true;
        int numberOfResults = GetComponent<BoxCollider2D>().OverlapCollider(contactFilter, results);

        Debug.Log(numberOfResults);
    }
}
