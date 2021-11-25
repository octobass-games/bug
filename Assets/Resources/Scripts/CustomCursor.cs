using System.Collections;
using UnityEngine;

public class CustomCursor : MonoBehaviour
{
    public Texture2D Dragging;
    public Texture2D Clickable;
    public Texture2D Draggable;
    public Texture2D Neutral;

    private Texture2D CurrentTexture;

    void Awake() => MaybeSetNeutralCursor();

    public void MaybeSetNeutralCursor() => SetCursor(Neutral);

    public void SetDraggingCursor()
    {
        SetCursor(Dragging);
    }

    public void MaybeSetDraggableCursor() => SetCursor(Draggable);
    public void MaybeSetClickableCursor() => SetCursor(Clickable);

    private void SetCursor(Texture2D texture)
    {
        if (CurrentTexture != texture)
        {
            CurrentTexture = texture;

            Vector2 cursorOffset = new Vector2(texture.width / 2, 0);
            Cursor.SetCursor(texture, cursorOffset, CursorMode.Auto);
        }
    }
}