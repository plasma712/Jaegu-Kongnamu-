using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyAnim : MonoBehaviour
{
    public int GetBeans;
    public bool Stop;
    private float StopTime;
    public BoxCollider2D BoxCollider;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    private Jack_anim JackAnim;
    public float DelTime;
    public int CurHp;
    public int MaxHp;
    ScriptManger sm;

    public float verticalMoveSpeed = 1f;
    public float horizontalMoveSpeed = 2f;
    public Floor[] FloorList;

    public Transform TargetTranform;
    private Rigidbody2D rb2d;
    public bool Grounded;
    public bool Die;
    public SlideUpText Slideprepabs;

    public Floor CurrentFloor; // control+r+r;
    public Floor TargetFloor;

    public BoxCollider2D characterCollider;
    public Ladder TargetLadder;
    public Ladder CurrentLadder;
    public Transform House;
    public float AttackDistance;
    private Floor EmptyObject;

    public float Fly = 1;
    public Jangsoo_Spot Jang_soo;


    // Use this for initialization
    private void Awake()
    {
        House = GameObject.FindGameObjectWithTag("House").GetComponent<Transform>();
        JackAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Jack_anim>();
        Jang_soo = GameObject.FindGameObjectWithTag("Jangsoo_Spot").GetComponent<Jangsoo_Spot>();

        for (int i = 0; i < FloorList.Length; i++)
        {
            switch (i)
            {
                case 0:
                    EmptyObject = GameObject.FindGameObjectWithTag("Floor1").GetComponent<Floor>();
                    FloorList[i] = EmptyObject;
                    break;

                case 1:
                    EmptyObject = GameObject.FindGameObjectWithTag("Floor2").GetComponent<Floor>();
                    FloorList[i] = EmptyObject;
                    break;

                case 2:
                    EmptyObject = GameObject.FindGameObjectWithTag("Floor3").GetComponent<Floor>();
                    FloorList[i] = EmptyObject;
                    break;

                case 3:
                    EmptyObject = GameObject.FindGameObjectWithTag("Floor4").GetComponent<Floor>();
                    FloorList[i] = EmptyObject;
                    break;

                case 4:
                    EmptyObject = GameObject.FindGameObjectWithTag("Floor5").GetComponent<Floor>();
                    FloorList[i] = EmptyObject;
                    break;

                case 5:
                    EmptyObject = GameObject.FindGameObjectWithTag("Floor6").GetComponent<Floor>();
                    FloorList[i] = EmptyObject;
                    break;

                default:
                    break;
            }
        }
    }

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine("ChangeMovement");
        Die = false;
        CurHp = MaxHp* Jang_soo.Hp_maxPlus;
        sm = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<ScriptManger>();
        CurrentFloor = GetFloorByPosition(transform.position);
        TargetFloor = CurrentFloor;
    }

    private void Update()
    {
        PestHelath();
        ChaseMousePosition();
        TargetTranform = House;
        TargetFloor = GetFloorByPosition(TargetTranform.position);
    }

    void PestHelath()
    {
        if (CurHp <= 0)
        {
            animator.SetBool("_Hitting", true);
            Destroy(this.gameObject, 1.0f);
            Die = true;

            if (Die == true && DelTime == 0)
            {
                Vector3 vec3 = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
                Instantiate(Slideprepabs, vec3, Quaternion.identity);
                sm.PlusBeans(GetBeans);
            }
            DelTime += Time.deltaTime;
        }
    }

    void ChaseMousePosition()
    {
        Vector3 vec3;
        vec3 = JackAnim.TargetTranform.position;
        float PestPositionX = transform.position.x;
        float PestPositionY = transform.position.y;

        if (PestPositionX - BoxCollider.size.x * Mathf.Abs(transform.lossyScale.x) < vec3.x &&
            PestPositionX + BoxCollider.size.x * Mathf.Abs(transform.lossyScale.x) > vec3.x &&
            PestPositionY - BoxCollider.size.y * Mathf.Abs(transform.lossyScale.y) / 2 < vec3.y &&
            PestPositionY + BoxCollider.size.y * Mathf.Abs(transform.lossyScale.y) > vec3.y)
        {
            if (PestPositionX - BoxCollider.size.x * Mathf.Abs(transform.lossyScale.x) / 2 < JackAnim.transform.position.x &&
               PestPositionX + BoxCollider.size.x * Mathf.Abs(transform.lossyScale.x) / 2 > JackAnim.transform.position.x &&
               PestPositionY - BoxCollider.size.y * Mathf.Abs(transform.lossyScale.y) < JackAnim.transform.position.y &&
               PestPositionY + BoxCollider.size.y * Mathf.Abs(transform.lossyScale.y) > JackAnim.transform.position.y)
            {
                JackAnim.FlyHitAnim(this);
            }

        }
    }

    void FixedUpdate()
    {
        CharacterMoveLogic();
    }

    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(5f);

        StartCoroutine("ChangeMovement");
    }

    void HorizontalMove(float targetX)
    {
        
        if (Stop == true)
        {
            StopTime += Time.deltaTime;
            if(StopTime > 1.0f)
            {
                Stop = false;
                StopTime = 0;
            }
            return;       
        }

        var diffX = targetX - transform.position.x;
        var signX = Mathf.Sign(diffX);
        var movementDiff = signX * Time.deltaTime * horizontalMoveSpeed;

        var pos = transform.position;

        if (Mathf.Abs(diffX) < Mathf.Abs(movementDiff))
        {
            pos.x = targetX;
            if (TargetLadder)
            {
                CurrentLadder = TargetLadder;
                if (IsGoingUp())
                {
                    VerticalMove(GetFloorY(TargetLadder.UpFloor));
                }
                else
                {
                    VerticalMove(GetFloorY(TargetLadder.DownFloor));
                }
                return;
            }
        }
        else
        {
            pos.x += movementDiff;
        }

        transform.position = pos;

        if (diffX != 0)
        {
            movementFlag = signX < 0 ? 1 : 2;
            transform.localScale = new Vector3(25 * -signX, 25, 1);
            //animator.SetBool("_Walk", signX != 0);
        }
    }

    private void VerticalMove(float targetY)
    {
        var diffY = targetY - transform.position.y;
        var signY = Mathf.Sign(diffY);
        var movementDiff = signY * Time.deltaTime * verticalMoveSpeed;

        var pos = transform.position;
        if (Mathf.Abs(diffY) < Mathf.Abs(movementDiff))
        {
            pos.y = targetY;
            TargetLadder = null;
            CurrentLadder = null;
        }
        else
        {
            pos.y += movementDiff;
        }
        transform.position = pos;
    }

    private float GetFloorY(Floor floor)
    {
        return floor.transform.position.y + floor.FloorCollider.size.y * floor.transform.lossyScale.y / 2
             + characterCollider.size.y * transform.lossyScale.y / 2;
    }

    Floor GetFloorByPosition(Vector3 mousePosition)
    {
        for (int i = FloorList.Length - 1; i >= 0; i--)
        {
            if (FloorList[i].transform.position.y < mousePosition.y)
            {
                return FloorList[i];
            }
        }
        return FloorList[0];
    }

    void CharacterMoveLogic()
    {
        if (sm.CurHealth <= 0)
            return;

        if (Vector2.Distance(House.transform.position, transform.position) > AttackDistance)
        {
            if (TargetLadder == null)
            {
                CurrentFloor = GetFloorByPosition(transform.position);
            }

            if (TargetFloor != CurrentFloor && CurrentLadder == null)
            {
                if (IsGoingUp())
                {
                    TargetLadder = CurrentFloor.UpLadder;
                }
                else
                {
                    TargetLadder = CurrentFloor.DownLadder;
                }
                HorizontalMove(TargetLadder.transform.position.x);
            }
            else if (CurrentLadder != null)
            {
                if (IsGoingUp())
                {
                    VerticalMove(GetFloorY(CurrentLadder.UpFloor));
                }
                else
                {
                    VerticalMove(GetFloorY(CurrentLadder.DownFloor));
                }
            }
            else
            {
                TargetLadder = null;
                HorizontalMove(TargetTranform.position.x);
            }
        }
    }

    private bool IsGoingUp()
    {
        if (TargetFloor != CurrentFloor)
        {
            return TargetFloor.FloorIndex > CurrentFloor.FloorIndex;
        }
        else
        {
            return CurrentLadder.UpFloor == CurrentFloor;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "House")
        {
            animator.SetBool("_Attack", true);
            Debug.Log("어택");

            if (transform.position.x > House.transform.position.x)
            {
                transform.localScale = new Vector3(25, 25, 1);
            }
            if (transform.position.x < House.transform.position.x)
            {
                transform.localScale = new Vector3(-25, 25, 1);
            }

        }

    }
}
