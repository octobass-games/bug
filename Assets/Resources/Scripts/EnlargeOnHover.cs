using UnityEngine;

public class EnlargeOnHover : MonoBehaviour
{
    void OnMouseEnter() => transform.localScale = new Vector3(1.05f, 1.05f, 1.05f);

    void OnMouseExit() =>transform.localScale = new Vector3(1, 1, 1);
}
