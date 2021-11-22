using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundEveryNSeconds : MonoBehaviour
{
    public float IntervalTime;
    private float time;

    public string path;
    //public AudioSource AudioSource;
    //public AudioClip[] Sounds;

    FMOD.Studio.EventInstance soundEvent;


 
    private void Start()
    {
        if (path != "")
        {
            soundEvent = FMODUnity.RuntimeManager.CreateInstance(path);
            soundEvent.start();
        }
    }

    void Update()
    {
        time += Time.deltaTime;
        if (time > IntervalTime)
        {
            time = 0;

            soundEvent.start();
        }
    }
}
