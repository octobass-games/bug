using UnityEngine;

public class CursorProxy : MonoBehaviour
{
    private CustomCursor CustomCursor;
    // Use this for initialization
    void Awake()
    {
        CustomCursor = FindObjectOfType<CustomCursor>();
    }

    public void ResetCursor()
    {
        CustomCursor.SetNeutralCursor();
    }
}