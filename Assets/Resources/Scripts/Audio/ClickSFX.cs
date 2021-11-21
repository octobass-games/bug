using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSFX : MonoBehaviour
{
    FMOD.Studio.EventInstance clickSound;

    public string path;

    bool isPlaying = false;


    private void Start()
    {
        if (path != "")
        {
            clickSound = FMODUnity.RuntimeManager.CreateInstance(path);
        }
    }

    public void PlayOneShot()
    {
        if (path != "")
        {
            FMODUnity.RuntimeManager.PlayOneShot(path);
        }
    }

    public void PlayLoop()
    {
        if (isPlaying == false)
        {
            clickSound.start();
            isPlaying = true;
        }

        else if (isPlaying == true)
        {
            clickSound.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            isPlaying = false;
        }
    }
}
