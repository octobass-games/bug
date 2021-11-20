using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<GameObject> Items;
    public GameObject InventoryItemBackground;
    public Transform SpawnPoint;

    private const int SpaceBetweenItems = -40;

    public void Add(GameObject item)
    {
        item.AddComponent<Draggable>();

        Items.Add(item);

        item.transform.SetParent(transform);
        item.GetComponent<SpriteRenderer>().sortingLayerName = "Inventory";
        item.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

        var yOffset = SpaceBetweenItems * (Items.Count - 1);
        item.transform.position = new Vector3(transform.position.x, transform.position.y + yOffset, item.transform.position.z);

        var inventoryItemBackground = Instantiate(InventoryItemBackground);
        inventoryItemBackground.transform.position = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y + yOffset, InventoryItemBackground.transform.position.z);
        inventoryItemBackground.transform.SetParent(transform.parent);
        var inventoryItemBackgroundCenter = inventoryItemBackground.GetComponent<SpriteRenderer>().bounds.center;
        item.transform.position = new Vector3(inventoryItemBackgroundCenter.x, inventoryItemBackgroundCenter.y, item.transform.position.z);
    }
}
