using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    private FMOD.Studio.EventInstance musicEvent;
    private FMOD.Studio.PARAMETER_DESCRIPTION parameterController;

    void Start()
    {
        musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Music/All Tracks");
        musicEvent.start();
        DontDestroyOnLoad(GameObject.Find("Music"));

    }
}
