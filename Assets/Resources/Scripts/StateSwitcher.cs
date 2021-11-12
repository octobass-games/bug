using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class StateSwitcher : MonoBehaviour
{
    private bool ThingOneOn = false;
    private bool ThingTwoOn = false;

    public UnityEvent OnThingOneOn;
    public UnityEvent OnThingTwoOn;
    public UnityEvent OnBothOn;
    public UnityEvent OnBothOff;

    public void ToggleThingOne()
    {
        ThingOneOn = !ThingOneOn;
        Logic();
    }

    public void ToggleThingTwo()
    {
        ThingTwoOn = !ThingTwoOn;
        Logic();
    }

    private void Logic()
    {
        if (ThingOneOn && ThingTwoOn)
        {
            OnBothOn.Invoke();
            return;
        }

        if (ThingOneOn && !ThingTwoOn)
        {
            OnThingOneOn.Invoke();
            return;
        }

        if (!ThingOneOn && ThingTwoOn)
        {
            OnThingTwoOn.Invoke();
            return;
        }

        OnBothOff.Invoke();
    }

}