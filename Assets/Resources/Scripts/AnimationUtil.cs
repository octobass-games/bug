using UnityEngine;

public class AnimationUtil : MonoBehaviour
{
    public Animator Animator;
    public void SetBoolTrue(string name)
    {
        Animator.SetBool(name, true);
    }

    public void SetBoolFalse(string name)
    {
        Animator.SetBool(name, false);
    }


    public void ToggleBool(string name)
    {
        Animator.SetBool(name, !Animator.GetBool(name));
    }

}