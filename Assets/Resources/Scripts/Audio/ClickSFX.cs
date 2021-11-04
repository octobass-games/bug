using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSFX : MonoBehaviour
{
    bool isWrong = true;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isWrong == true)
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/clickWrong");
        }

        else if (Input.GetMouseButtonDown(0) && isWrong == false)
        {
            //FMODUnity.RuntimeManager.PlayOneShot("event:/");
        }
    }
    }
}
