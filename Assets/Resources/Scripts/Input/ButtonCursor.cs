using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class ButtonCursor : MonoBehaviour, IPointerEnterHandler , IPointerExitHandler
{

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
        GetCursor().SetClickableCursor();
    }


    public void OnPointerExit(PointerEventData eventData)
    {
        GetCursor().SetNeutralCursor();
    }

}