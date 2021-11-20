using UnityEngine;

public class EnlargeOnHover : MonoBehaviour
{
    void OnMouseEnter() => transform.localScale *= 1.05f;

    void OnMouseExit() => transform.localScale *= 0.95f;
}
