using UnityEngine;

public static class SpriteRendererExtension
{
    public static void SetOpacity(this SpriteRenderer source, float opacity)
    {
        source.color = new Vector4(source.color.r, source.color.g, source.color.b, opacity);
    }
}
