using UnityEngine;
using UnityEngine.Events;

public class MenuFallInOnEnabled : MonoBehaviour
{
    private Vector2 OrginalPostion;
    private float Speed = 300;
    private bool Complete = false;
    public int Offset = 500;
    public bool Loop = false;
    public bool RandomiseSpeed = false;
    public UnityEvent OnFallEnd;

    private RectTransform rect;
    void Awake()
    {
        rect = GetComponent<RectTransform>();
        Complete = true;
        if (RandomiseSpeed)
        {
            Speed = Random.Range(100, 500);
        }
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
            if (!Loop)
            {
                Complete = true;
                OnFallEnd?.Invoke();
            }
            else
            {
                MoveToTop();
            }
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