using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonCursor : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{
    private bool inButton;
    private CustomCursor CustomCursor;
    
    private CustomCursor GetCursor()
    {
        if (CustomCursor == null)
        {
            CustomCursor = FindObjectOfType<CustomCursor>();
        }
        return CustomCursor;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        GetCursor()?.SetClickableCursor();
        inButton = true;
    }
    
    void OnDisable()
    {
        if (inButton)
        {
            GetCursor()?.SetNeutralCursor();
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        GetCursor()?.SetNeutralCursor();
        inButton = false;
    }

}