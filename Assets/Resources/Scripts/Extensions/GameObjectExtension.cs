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

    public static T MaybeAddComponent<T>(this GameObject source) where T: MonoBehaviour 
    {
        var component = source.GetComponent<T>();
        if (component == null)
        {
            component = source.AddComponent<T>();
        }
        return component;
    }

}
