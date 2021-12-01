using System.Collections;
using UnityEngine;

public class SkipLevel : MonoBehaviour
{
    public GameObject SkipButton;
    // Use this for initialization
    void OnEnable()
    {
        bool show = FindObjectOfType<Levels>().CurrentLevel != null;

        SkipButton.SetActive(show);

    }
}