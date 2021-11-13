using System.Collections;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D Dragging;
    public Texture2D Clickable;
    public Texture2D Draggable;
    public Texture2D Neutral;

    void Awake()
    {
        SetNeutralCursor();
    }

    public void SetNeutralCursor() => SetCursor(Neutral);
    public void SetDraggingCursor() => SetCursor(Dragging);
    public void SetDraggableCursor() => SetCursor(Draggable);
    public void SetClickableCursor() => SetCursor(Clickable);

    private void SetCursor(Texture2D texture)
    {
        Vector2 cursorOffset = new Vector2(texture.width / 2, 0);
        Cursor.SetCursor(texture, cursorOffset, CursorMode.Auto);
    }

}