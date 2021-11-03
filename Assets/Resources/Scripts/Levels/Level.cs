public enum StarRating
{
    ONE,
    TWO,
    THREE,
}

public class Level
{
    public LevelData Data;
    public bool Locked = true;
    public int LowestInteractionScore;

    public Level(LevelData data, bool locked = true)
    {
        Data = data;
        Locked = locked;
    }

    public int GetStarRating(int interactions)
    {
        if (interactions <= Data.ThreeStarInteractionCount)
        {
            return 3;
        }

        if (interactions <= Data.TwoStarInteractionCount)
        {
            return 2;
        }

        return 1;
    }

    public void UpdateInteractionCount(int count)
    {
        if (LowestInteractionScore > count)
        {
            LowestInteractionScore = count;
        }
    }
}