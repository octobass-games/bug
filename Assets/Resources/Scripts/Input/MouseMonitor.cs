using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class MouseMonitor : MonoBehaviour
{
    private CustomCursor CustomCursor;
    private Draggable Draggable;

    void Start()
    {
        CustomCursor = FindObjectOfType<CustomCursor>();
    }

    void Update()
    {
        var gameObjectBeneathMouse = FindObjectOfTypeBeneathMouse<Collider2D>()?.gameObject;

        if (gameObjectBeneathMouse != null && gameObjectBeneathMouse != Draggable?.gameObject)
        {
            if (gameObjectBeneathMouse.GetComponent<Inspectable>() != null)
            {
                if (Draggable != null)
                {
                    CustomCursor.MaybeSetDraggableCursor();
                }
                else
                {
                    CustomCursor.MaybeSetClickableCursor();
                }
            }
            else if (gameObjectBeneathMouse.GetComponent<Draggable>() != null)
            {
                if (Draggable == null)
                {
                    CustomCursor.MaybeSetDraggableCursor();
                }
            }
            else
            {
                CustomCursor.MaybeSetNeutralCursor();
            }
        }
        else if (Draggable != null)
        {
            CustomCursor.SetDraggingCursor();
        }
        else
        {
            CustomCursor.MaybeSetNeutralCursor();
        }
    }

    public void OnClick(InputAction.CallbackContext ctx)
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
            else
            {
                FindObjectOfTypeBeneathMouse<Inspectable>()?.Inspect();
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

        if (Camera.main != null)
        {
            var ray = Camera.main.ScreenPointToRay(mousePosition);
            var hit = Physics2D.Raycast(ray.origin, ray.direction);

            return hit.collider?.GetComponent<T>();
        }

        return null;
    }

    private bool IsMouseOverUIElement() => EventSystem.current.IsPointerOverGameObject();
}
