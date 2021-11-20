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

    public void Add(GameObject item)
    {
        Items.Add(item);

        var yOffset = SpaceBetweenItems * (Items.Count - 1);

        var inventoryItemBackground = Instantiate(InventoryItemBackground);
        inventoryItemBackground.transform.position = new Vector3(SpawnPoint.position.x, SpawnPoint.position.y + yOffset, InventoryItemBackground.transform.position.z);
        inventoryItemBackground.transform.SetParent(transform.parent);
        var inventoryItemBackgroundCenter = inventoryItemBackground.GetComponent<SpriteRenderer>().bounds.center;

        item.AddComponent<Draggable>();
        item.GetComponent<SpriteRenderer>().sortingLayerName = "Inventory";
        item.transform.SetParent(transform);
        item.transform.localScale *= 0.75f;
        item.transform.position = new Vector3(inventoryItemBackgroundCenter.x, inventoryItemBackgroundCenter.y, item.transform.position.z);
    }
}
