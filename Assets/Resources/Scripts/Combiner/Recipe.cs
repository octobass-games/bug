using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Recipe
{
    public GameObject ComponentA;
    public GameObject ComponentB;
    public GameObject Result;
    public bool ShouldMoveResultPostition = false;
    public bool ShouldPlaceInInventoryOnCombination = false;
    public bool ShouldDestroyComponentAOnCompletion = true;
    public bool ShouldDestroyComponentBOnCompletion = true;

    public UnityEvent OnCombination;
}