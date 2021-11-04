using UnityEngine;

public class MenuFallInOnEnabled : MonoBehaviour
{
    private Vector2 OrginalPostion;
    private float Speed = 300;
    private bool Complete = false;
    public int Offset = 1;

    private RectTransform rect;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        Complete = true;
        Init();
    }

    void Update()
    {
        if (Complete)
        {
            return;
        }

        float step = Speed * Time.deltaTime;
        rect.anchoredPosition = Vector2.MoveTowards(rect.anchoredPosition, OrginalPostion, step);

        if(rect.anchoredPosition == OrginalPostion)
        {
            Complete = true;
        }
    }

    void OnEnable()
    {
        MoveToTop();
        Complete = false;
    }

    private void Init()
    {
        OrginalPostion = rect.anchoredPosition;
        MoveToTop();
    }

    private void MoveToTop()
    {
        rect.anchoredPosition = OrginalPostion + new Vector2(0, Offset);
    }
}