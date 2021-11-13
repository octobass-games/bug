using System.Collections.Generic;
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
        shadows.ForEach(s => {
            s.ShadowOn(ShadowsOn);
         });

        if (ShadowsOn)
        {
            OnShadowsOn.Invoke();
        } else {
            OnShadowsOff.Invoke();
        }
    }
}