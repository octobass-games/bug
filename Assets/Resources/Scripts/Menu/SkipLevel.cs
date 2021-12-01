using System.Collections;
using UnityEngine;

public class SkipLevel : MonoBehaviour
{
    public GameObject SkipButton;
    // Use this for initialization
    void OnEnable()
    {
        var levels = FindObjectOfType<Levels>();
        bool isPlaying = levels.CurrentLevel != null && levels.CurrentLevel?.Data != null;
        bool isLastLevel = levels.IsLastLevel();

        SkipButton.SetActive(isPlaying && !isLastLevel);

    }
}