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

    public int GetStarRating(int interactionCount)
    {
        if (interactionCount <= Data.ThreeStarInteractionCount)
        {
            return 3;
        }
        else if (interactionCount <= Data.TwoStarInteractionCount)
        {
            return 2;
        }
        else
        {
            return 1;

        }
    }

    public void UpdateInteractionCount(int interactionCount)
    {
        if (LowestInteractionScore > interactionCount)
        {
            LowestInteractionScore = interactionCount;
        }
    }
}