using UnityEngine;

public class FallInOnLoad : MonoBehaviour
{
    private Vector3 OrginalPostion;
    public float CustomSpeed = 0;
    private float Speed ;
    private bool Complete = false;
    public bool FallOnEnable = false;
    private int OffsetFall = 100;


    void Start()
    {
        Init();
    }

    void Update()
    {
        if (Complete)
        {
            return;
        }

        float step = Speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, OrginalPostion, step);

        if(transform.position == OrginalPostion)
        {
            Complete = true;
        }
    }

    void OnEnable()
    {
       if (FallOnEnable)
        {
            Init();
            Complete = false;
        }    
    }

    private void Init()
    {
        if (CustomSpeed == 0)
        {
            Speed = Random.Range(100f, 300f);
        }
        else
        {
            Speed = CustomSpeed;
        }
        OrginalPostion = transform.position;
        transform.position = OrginalPostion + new Vector3(0, OffsetFall, 0);
    }
}