using UnityEngine;

public class DraggableWithinBounds : Draggable
{
    public BoxCollider2D Bounds;

    public override void DragEnd()
    {
        if (IsDragging)
        {
            IsDragging = false;
            SpriteRenderer.sortingLayerName = StartSortingLayerName;
            DestroyGhost();

            if (!Bounds.Distance(Collider).isOverlapped)
            {
                transform.position = Ghost.transform.position;
            }
        }
    }

}
