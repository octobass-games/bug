using UnityEngine;

public class LevelSelectorRenderer : MonoBehaviour
{
    public Levels Levels;
    public GameObject Panel;
    public GameObject LevelPrefab;

    void Start()
    {
        Panel.DestroyChildren();
        Levels.LevelList.ForEach(RenderItem);
    }

    private void RenderItem(Level level)
    {
        if (!level.Locked)
        {
            GameObject collectableObject = Instantiate(LevelPrefab);
            collectableObject.transform.SetParent(Panel.transform);
        }
    }
}