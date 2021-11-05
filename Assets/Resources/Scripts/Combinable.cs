using UnityEngine;
using UnityEngine.Events;

public class Combinable : MonoBehaviour
{
    public GameObject CombinableComponent;
    public UnityEvent OnCombine;

    public void Combine(GameObject gameObject)
    {
        if (gameObject == CombinableComponent)
        {
            OnCombine.Invoke();
        }
    }
}
