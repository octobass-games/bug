using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMonitor : MonoBehaviour
{

    public void OnClick()
    {
        GetColliderBeneathMouse()?.GetComponent<OnClick>()?.Invoke();
    }

    public void OnDrag(InputAction.CallbackContext ctx)
    {
        var draggableBeneathMouse = GetColliderBeneathMouse()?.GetComponent<Draggable>();

        if (draggableBeneathMouse)
        {
            if (ctx.started)
            {
                draggableBeneathMouse.DragStart();
            }
            else
            {
                draggableBeneathMouse.DragEnd();
            }
        }
    }

    private Collider2D GetColliderBeneathMouse()
    {
        var mousePosition = Mouse.current.position.ReadValue();

        var ray = Camera.main.ScreenPointToRay(mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction);

        return hit.collider;
    }
}
