using System.Collections.Generic;

public struct SaveData
{
    public List<Level> Levels;
    public List<Collectable> Collectables;

    public SaveData(List<Level> levels, List<Collectable> collectables)
    {
        Levels = levels;
        Collectables = collectables;
    }
}