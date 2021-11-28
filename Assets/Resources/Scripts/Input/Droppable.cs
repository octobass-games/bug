using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class Droppable : MonoBehaviour
{
    public List<Collider2D> Colliders;

    public UnityEvent OnIsEmpty;
    public UnityEvent OnIsNotEmpty;
    public Collider2D Collider;

    public void Validate()
    {
        bool hasItemsOverlapped = Colliders.Any(c => c.Distance(Collider).isOverlapped);

        if (hasItemsOverlapped)
        {
            OnIsNotEmpty.Invoke();
        }else
        {
            OnIsEmpty.Invoke();
        }
    }

}