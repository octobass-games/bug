using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Items;
    public GameObject InventoryItemBackground;
    [FormerlySerializedAs("SpawnPoint")]
    public Transform SpawnPoint;

    private const int SpaceBetweenItems = -40;
    private List<GameObject> Backgrounds = new List<GameObject>();

    public void Add(GameObject item)
    {
        Items.Add(item);

        Destroy(item.GetComponent<Pickupable>());
        Destroy(item.GetComponent<Inspectable>());

        Draw();
    }

    public void Remove(GameObject item)
    {
        Items.Remove(item);
        Draw();
    }

    private void Draw()
    {
        Backgrounds.ForEach(background => Destroy(background));

        for (int i = 0; i < Items.Count; ++i)
        {
            var item = Items[i];

            var yOffset = SpaceBetweenItems * i;

            var inventoryItemBackground = Instantiate(InventoryItemBackground);
            Backgrounds.Add(inventoryItemBackground);
            inventoryItemBackground.transform.position = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y + yOffset, InventoryItemBackground.transform.position.z);
            inventoryItemBackground.transform.SetParent(transform.parent);
            var inventoryItemBackgroundCenter = inventoryItemBackground.GetComponent<SpriteRenderer>().bounds.center;

            item.MaybeAddComponent<Draggable>();
            var sprite = item.GetComponent<SpriteRenderer>();
            sprite.sortingLayerName = "Inventory";
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b);
            item.transform.SetParent(transform);
            item.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);
            item.transform.position = new Vector3(inventoryItemBackgroundCenter.x, inventoryItemBackgroundCenter.y, item.transform.position.z);
        }
    }
}
