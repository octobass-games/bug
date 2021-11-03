using UnityEngine;
using UnityEngine.InputSystem;

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

    public void DragStart()
    {
        isDragging = true;
    }

    public void DragEnd()
    {
        isDragging = false;
    }
}
