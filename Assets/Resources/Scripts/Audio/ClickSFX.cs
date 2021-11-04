using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSFX : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            FMODUnity.RuntimeManager.PlayOneShot("event:/SFX/clickWrong");
        }
    }
}
