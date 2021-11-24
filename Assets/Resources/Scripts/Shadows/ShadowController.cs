using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class ShadowController : MonoBehaviour
{

    public Color ShadowColour;
    public bool ShadowsOn = true;
    public UnityEvent OnShadowsOn;
    public UnityEvent OnShadowsOff;

    private List<AddShadow> shadows = new List<AddShadow>();
    public void Register(AddShadow shadow)
    {
        shadows.Add(shadow);
        shadow.ShadowOn(ShadowsOn);
    }

    public void Unregister(AddShadow shadow)
    {
        shadows.Remove(shadow);
    }

    public void ToggleShadows()
    {
        ShadowsOn = !ShadowsOn;
        UpdateShadows();
    }

    public void LightOnViaId(string id)
    {
        ShadowsOn = !ShadowsOn;
        shadows.Where(s => s.GetId() == id).ToList().ForEach(s => s.ShadowOn(ShadowsOn));
        InvokeHooks();
    }


    public void LightOn()
    {
        ShadowsOn = false;
        UpdateShadows();
    }


    private void UpdateShadows()
    {
        shadows.ForEach(s =>  s.ShadowOn(ShadowsOn));

        InvokeHooks();
    }

    private void InvokeHooks()
    {
        if (ShadowsOn)
        {
            OnShadowsOn.Invoke();
        }
        else
        {
            OnShadowsOff.Invoke();
        }
    }
}