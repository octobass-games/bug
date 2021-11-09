using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSFX : MonoBehaviour
{
    FMOD.Studio.EventInstance loopSound;

    public string path;

    bool isPlaying = false;

    private void Start()
    {
        loopSound = FMODUnity.RuntimeManager.CreateInstance(path);
    }

    public void PlayOneShot()
    {
        FMODUnity.RuntimeManager.PlayOneShot(path);
    }

    public void PlayLoop(string Path)
    {
        if (isPlaying == false)
        {
            loopSound.start();
            isPlaying = true;
        }

        else if (isPlaying == true)
        {
            loopSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isPlaying = false;
        }
    }
}
