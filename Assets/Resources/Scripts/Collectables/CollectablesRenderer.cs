using UnityEngine;

public class CollectablesRenderer : MonoBehaviour
{
    public Collectables Collectables;
    public GameObject Panel;
    public GameObject CollectablePrefab;

    void Start()
    {
        Panel.DestroyChildren();
        Collectables.CollectableList.ForEach(RenderItem);
    }

    private void RenderItem(Collectable collectable)
    {
        if (!collectable.Locked)
        {
            GameObject collectableObject = Instantiate(CollectablePrefab);
            collectableObject.transform.SetParent(Panel.transform);
        }
    }
}