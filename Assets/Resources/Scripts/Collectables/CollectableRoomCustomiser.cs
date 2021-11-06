using System.Collections.Generic;
using UnityEngine;

public class CollectableRoomCustomiser : MonoBehaviour
{
    public List<Color> Colours;

    public void RotateColour(SpriteRenderer sprite)
    {
        var currentColourIndex = Colours.FindIndex(c => c == sprite.color);
        var next = Colours.NextIndex(currentColourIndex);
        sprite.color = Colours[next];
    }
}