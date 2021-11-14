using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseMonitor : MonoBehaviour
{
    private Draggable Draggable;

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
            FindObjectOfTypeBeneathMouse<Inspectable>()?.Inspect();
        }
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        if (ctx.started)
        {
            Draggable = FindObjectOfTypeBeneathMouse<Draggable>();

            if (Draggable != null)
            {
                Draggable.DragStart();
            }
        }
        else if (ctx.performed)
        {
            if (Draggable != null)
            {
                Draggable.DragEnd();
                Draggable = null;
            }
        }
    }

    private T FindObjectOfTypeBeneathMouse<T>() where T : class
    {
        if (IsMouseOverUIElement())
        {
            return null;
        }

        var mousePosition = Mouse.current.position.ReadValue();

        var ray = Camera.main.ScreenPointToRay(mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction);

        return hit.collider?.GetComponent<T>();
    }

    private bool IsMouseOverUIElement() => EventSystem.current.IsPointerOverGameObject();
}
