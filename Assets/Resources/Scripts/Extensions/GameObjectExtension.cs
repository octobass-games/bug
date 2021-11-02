using UnityEngine;

public static class GameObjectExtension
{
    public static void DestroyChildren(this GameObject source)
    {
        foreach (Transform child in source.transform)
        {
            GameObject.Destroy(child.gameObject);
        }
    }

}
