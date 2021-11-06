using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseMonitor : MonoBehaviour
{

    public void OnClick(InputAction.CallbackContext ctx)
    {
        if (ctx.performed)
        {
           FindObjectOfTypeBeneathMouse<OnClick>()?.Invoke();
        }
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        var draggableBeneathMouse = FindObjectOfTypeBeneathMouse<Draggable>();

        if (draggableBeneathMouse)
        {
            if (ctx.started)
            {
                draggableBeneathMouse.DragStart();
            }
            else if (ctx.performed)
            {
                draggableBeneathMouse.DragEnd();
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
