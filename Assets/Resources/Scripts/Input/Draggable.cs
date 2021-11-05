using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Collider2D))]
public class Draggable : MonoBehaviour
{
    public GameObject Ghost;

    private SpriteRenderer SpriteRenderer;
    private Vector3 PositionBeforeDragging;
    private bool IsDragging;
    private Collider2D[] OverlappingColliders = new Collider2D[1];
    private ContactFilter2D ContactFilter = new ContactFilter2D
    {
        useTriggers = true
    };

    void Start()
    {
        SpriteRenderer = GetComponent<SpriteRenderer>();

        var spriteRendererSprite = SpriteRenderer.sprite;

        Ghost = new GameObject("ghost");
        var ghostSpriteRenderer = Ghost.AddComponent<SpriteRenderer>();
        ghostSpriteRenderer.sprite = spriteRendererSprite;
        ghostSpriteRenderer.color = new Color(ghostSpriteRenderer.color.r, ghostSpriteRenderer.color.g, ghostSpriteRenderer.color.b, 0.4f);
        ghostSpriteRenderer.sortingLayerName = "Ghost";
        Ghost.transform.SetParent(transform.parent);
        Ghost.transform.position = transform.position;
    }

    void Update()
    {
        if (IsDragging)
        {
            var mouseWorldPoint = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
            transform.position = new Vector3(mouseWorldPoint.x, mouseWorldPoint.y, transform.position.z);
        }
    }

    void OnMouseEnter()
    {
        transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);
    }

    void OnMouseExit()
    {
        transform.localScale = new Vector3(1, 1, 1);
    }

    public void DragStart()
    {
        IsDragging = true;
        PositionBeforeDragging = transform.position;
        SpriteRenderer.sortingLayerName = "Drag";
    }

    public void DragEnd()
    {
        if (IsDragging)
        {
            IsDragging = false;
            SpriteRenderer.sortingLayerName = "Default";

            if (GetComponent<BoxCollider2D>().OverlapCollider(ContactFilter, OverlappingColliders) > 0)
            {
                FindObjectOfType<Combiner>().Combine(gameObject, OverlappingColliders[0].gameObject);
            }
            else
            {
                transform.position = PositionBeforeDragging;
            }
        }
    }
}
