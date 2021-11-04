using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicLoader : MonoBehaviour
{
    FMOD.Studio.EventInstance musicEvent;
    FMOD.Studio.PARAMETER_ID parameterController;
    [FMODUnity.EventRef]

    float updatedParameter;

    [SerializeField]
    float parameterNumber;
   


    void Start()
    {
        musicEvent = FMODUnity.RuntimeManager.CreateInstance("event:/Music/All Tracks");

        musicEvent.start();
        DontDestroyOnLoad(GameObject.Find("Music"));
    }

    void Update()
    {
        updatedParameter = SetMusicParameter();
        musicEvent.setParameterByName("isPaused", updatedParameter);
    }
    private float SetMusicParameter()
    {
        if (GameObject.Find("PausedMenu").activeSelf)
        {
            parameterNumber = 1f;
        }
        else
        {
            parameterNumber = 0f;
        }
        
        return parameterNumber;
    }

    
}
