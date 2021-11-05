using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    private GameObject Ghost;
    private Vector3 PositionBeforeDragging;
    private bool IsDragging;
    private Collider2D[] OverlappingColliders = new Collider2D[1];
    private ContactFilter2D ContactFilter = new ContactFilter2D
    {
        useTriggers = true
    };

    void Start()
    {
        var spriteRendererSprite = GetComponent<SpriteRenderer>().sprite;

        Ghost = new GameObject("ghost");
        var ghostSpriteRenderer = Ghost.AddComponent<SpriteRenderer>();
        ghostSpriteRenderer.sprite = spriteRendererSprite;
        ghostSpriteRenderer.color = new Color(ghostSpriteRenderer.color.r, ghostSpriteRenderer.color.g, ghostSpriteRenderer.color.b, 0.4f);
        Ghost.transform.SetParent(this.transform.parent);
        Ghost.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
    }

    void Update()
    {
        if (IsDragging)
        {
            var mouseWorldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, transform.position.z);
        }
    }

    public void DragStart()
    {
        IsDragging = true;
        PositionBeforeDragging = transform.position;
    }

    public void DragEnd()
    {
        IsDragging = false;

        if (GetComponent<BoxCollider2D>().OverlapCollider(ContactFilter, OverlappingColliders) > 0)
        {
            OverlappingColliders[0].gameObject.GetComponent<Combinable>()?.Combine(gameObject);
            Destroy(Ghost);
        }
        else
        {
            transform.position = PositionBeforeDragging;
        }
    }
}
