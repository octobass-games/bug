using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class Recipe
{
    public GameObject ComponentA;
    public GameObject ComponentB;
    public GameObject Result;
    public bool ShouldMoveResultPostition = false;
    public UnityEvent OnCombination;
}