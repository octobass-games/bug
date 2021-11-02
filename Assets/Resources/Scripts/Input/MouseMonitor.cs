using UnityEngine;
using UnityEngine.InputSystem;

public class MouseMonitor : MonoBehaviour
{
    public void OnClick()
    {
        GetColliderBeneathMouse()?.GetComponent<OnClick>()?.Invoke();
    }

    public void OnDrag()
    {
        GetColliderBeneathMouse()?.GetComponent<Draggable>()?.Drag();
    }

    private Collider2D GetColliderBeneathMouse()
    {
        var mousePosition = Mouse.current.position.ReadValue();

        var ray = Camera.main.ScreenPointToRay(mousePosition);
        var hit = Physics2D.Raycast(ray.origin, ray.direction);

        return hit.collider;
    }
}
