using UnityEngine;

public class AnimatorProxy : MonoBehaviour
{
    public Animator Animator;

    public void SetBoolTrue(string name) => Animator.SetBool(name, true);

    public void SetBoolFalse(string name) => Animator.SetBool(name, false);

    public void ToggleBool(string name) => Animator.SetBool(name, !Animator.GetBool(name));

    public void SetLayerWeightToOne(int index) => Animator.SetLayerWeight(index, 1);

    public void SetLayerWeightToZero(int index) => Animator.SetLayerWeight(index, 0);
}