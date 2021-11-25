using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LevelData : ScriptableObject
{
    public string SceneName;
    public string Name;
    public Sprite Sprite;
    public Sprite Preview;

    public int TwoStarInteractionCount = 2;
    public int ThreeStarInteractionCount = 3;

    public List<Sprite> FallingSprites;

    public float MusicSelector;
}