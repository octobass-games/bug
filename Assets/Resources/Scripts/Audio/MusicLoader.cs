using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    FMOD.Studio.EventInstance musicEvent;

    [FMODUnity.EventRef]
    float updatedParameter;
    [SerializeField]
    float parameterNumber;


    public void Start()
    {
        musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Music/All Tracks");

        musicEvent.start();
        DontDestroyOnLoad(GameObject.Find("Music"));
    }

    public float SetMusicParameter()
    {
        if (GameObject.Find("PauseMenu").activeSelf)
        {
            parameterNumber = 1f;
        }
        else
        {
            parameterNumber = 0f;
        }
        
        return parameterNumber;
    }

    public void SetMenuMusic(bool MenuOpen)
    {
        updatedParameter = MenuOpen ? 1f : 0f;
        musicEvent.setParameterByName("isPaused", updatedParameter);
    }


    //|| GameObject.Find("Level Select").activeSelf || GameObject.Find("Collectables").activeSelf

}
