using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Jack_anim : MonoBehaviour
{
    private FlyAnim TargetFly;
    private RL_Anim TargetPest;
    public int JackDamage;
    public float JumpStartTime;
    public float JumpTotalTime = 1f;
    public float JumpHeight = 100f;
    public float verticalMoveSpeed = 1f;
    public float horizontalMoveSpeed = 2f;
    public Floor[] FloorList;

    Animator animator;
    private float BugdTime;
    public int movementFlag = 0;
    public Transform TargetTranform;
    public float jumpPower;
    public bool Grounded;
    private double JumpSpeed;
    private float limitTime;
    public bool RopeClimbing;
    public bool Walk;
    public bool JumpTrigger;
    public bool HitBug;
    public bool DoubleAttack;
    public bool Attacking;

    public Floor CurrentFloor; // control+r+r;
    public Floor TargetFloor;

    public BoxCollider2D characterCollider;
    public Ladder TargetLadder;
    public Ladder CurrentLadder;
    public AudioSource myAudio;
    public SoundManager soundManager;
    bool bug;

    public Enemy_Random ER;
    public GameObject CriticalObject;


    public GameObject HitEffect;

    public ScriptManger Sm;

    public float Jack_Cry = 0;

    private void Awake()
    {
        TargetTranform.position = transform.position;
    }
    // Use this for initialization

    void Start()
    {
        myAudio = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponentInChildren<Animator>();
        StartCoroutine("ChangeMovement");
        Grounded = true;
        CurrentFloor = GetFloorByPosition(transform.position);
        TargetFloor = CurrentFloor;
        RopeClimbing = false;
        Walk = false;
        HitBug = false;
    }

    void FixedUpdate()
    {
        Fixed();
        CharacterMoveLogic();
    }

    void Fixed()
    {
        animator.SetBool("_RopeClimbing", RopeClimbing);
        animator.SetBool("_Jump", JumpTrigger);
        animator.SetBool("_Bug", HitBug);
        JackCry();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (JumpTrigger == false)
            {
                TargetTranform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                TargetFloor = GetFloorByPosition(TargetTranform.position);

                if (Sm.ButtonActive == true)
                    Sm.ButtonActive = false;
            }
        }
    }

    IEnumerator ChangeMovement()
    {
        yield return new WaitForSeconds(5f);

        StartCoroutine("ChangeMovement");
    }

    void HorizontalMove(float targetX)
    {
        if (Attacking == true)
            return;

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
            if (HitBug == false)
            {
                pos.x += movementDiff;
            }
        }

        var jumpTimeElapsed = Time.time - JumpStartTime;
        var jumpDiffY = JumpHeight * Mathf.Sin(jumpTimeElapsed / JumpTotalTime * Mathf.PI);

        if (JumpTotalTime > jumpTimeElapsed && JumpStartTime != 0)
        {
            pos.y = GetFloorY(CurrentFloor) + jumpDiffY;
            JumpTrigger = true;
        }
        else
        {
            pos.y = GetFloorY(CurrentFloor);
            JumpTrigger = false;
        }


        transform.position = pos;


        if (diffX != 0)
        {
            movementFlag = signX < 0 ? 1 : 2;
            transform.localScale = new Vector3(25 * -signX, 25, 1);

            if (RopeClimbing == false)
            {
                animator.SetBool("_Walk", signX != 0);
            }
        }
        else
        {
            movementFlag = 0;
            if (RopeClimbing == false)
            {
                animator.SetBool("_Walk", false);
            }
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
            RopeClimbing = false;
        }
        else
        {
            pos.y += movementDiff;
            RopeClimbing = true;
            Walk = false;
            JumpTrigger = false;
        }
        transform.position = pos;
    }

    private float GetFloorY(Floor floor)
    {
        return floor.transform.position.y + floor.FloorCollider.size.y * floor.transform.lossyScale.y / 2
             + characterCollider.size.y * transform.lossyScale.y / 2;
    }

    private float GetFloorXLeft(Floor floor)
    {
        return floor.transform.position.x - floor.FloorCollider.size.x * floor.transform.lossyScale.x / 2;
    }

    private float GetFloorXRight(Floor floor)
    {
        return floor.transform.position.x + floor.FloorCollider.size.x * floor.transform.lossyScale.x / 2;
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
        if (Sm.ButtonActive == true)
        {
            animator.SetBool("_Walk", false);
            if (JumpTrigger == false)
            {
                return;
            }
        }

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

        if (!IsJackFloor())
        {
            if (GetFloorXLeft(CurrentFloor) > transform.position.x)
            {
                transform.position = new Vector3(GetFloorXLeft(CurrentFloor), transform.position.y, transform.position.z);
                animator.SetBool("_Walk", false);
            }
            else if (GetFloorXRight(CurrentFloor) < transform.position.x)
            {
                transform.position = new Vector3(GetFloorXRight(CurrentFloor), transform.position.y, transform.position.z);
                animator.SetBool("_Walk", false);
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

    internal void Jump()
    {
        myAudio.PlayOneShot(soundManager.JumpingSound);
        JumpStartTime = Time.time;
    }

    internal void JumpCompare(BoxCollider2D boxCollider)
    {
        if (transform.localScale.x > 0)
        {
            if (TargetTranform.position.x > boxCollider.transform.position.x - (boxCollider.size.x * boxCollider.transform.lossyScale.x)
                && TargetTranform.position.x < boxCollider.transform.position.x + (boxCollider.size.x * boxCollider.transform.lossyScale.x))
            {
                Vector3 vec3 = new Vector3(boxCollider.transform.position.x - (boxCollider.size.x * boxCollider.transform.lossyScale.x),
                    TargetTranform.position.y, TargetTranform.position.z);

                TargetTranform.position = vec3;
            }
        }
        else
        {
            if (TargetTranform.position.x > boxCollider.transform.position.x - (boxCollider.size.x * boxCollider.transform.lossyScale.x)
                && TargetTranform.position.x < boxCollider.transform.position.x + (boxCollider.size.x * boxCollider.transform.lossyScale.x))
            {
                Vector3 vec3 = new Vector3(boxCollider.transform.position.x + (boxCollider.size.x * boxCollider.transform.lossyScale.x),
                    TargetTranform.position.y, TargetTranform.position.z);

                TargetTranform.position = vec3;
            }
        }
    }

    internal void ControlJump(float changeHeight, float changeTotal)
    {
        JumpHeight = changeHeight;
        JumpTotalTime = changeTotal;
    }

    internal void FlyHitAnim(FlyAnim targetFly)
    {
        TargetFly = targetFly;
        if (TargetFly == null || JumpTrigger == true || CurrentLadder != null)
            return;
        else
        {
            if (TargetFly.CurHp > 0)
            {
                HitBug = true;
            }
            else if (TargetFly.CurHp <= 0)
            {
                HitBug = false;
            }

            TargetTranform.position = transform.position;
            if (TargetFly.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-25, 25, 1);
            }
            else if (TargetFly.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(25, 25, 1);
            }

            if (Input.GetMouseButtonDown(0))
            {
                DoubleAttack = true;
            }
        }
    }

    void Attack()
    {
        if (TargetFly != null)
        {
            if (IsDoubleAttack())
            {
                TargetFly.CurHp -= JackDamage * 2;
                Instantiate(CriticalObject, TargetTranform.position, Quaternion.identity);
                soundManager.myAudio.PlayOneShot(soundManager.CriticalAttackSound);
                TargetFly.Stop = true;
                CreateHit();
            }
            else
            {
                TargetFly.CurHp -= JackDamage;
                soundManager.myAudio.PlayOneShot(soundManager.AttackSound);
                TargetFly.Stop = true;
                CreateHit();
            }

        }

        if (TargetPest != null)
        {
            if (IsDoubleAttack())
            {
                TargetPest.CurHp -= JackDamage * 2;
                Instantiate(CriticalObject, TargetTranform.position, Quaternion.identity);
                soundManager.myAudio.PlayOneShot(soundManager.CriticalAttackSound);
                TargetPest.Stop = true;
                CreateHit();

            }
            else
            {
                TargetPest.CurHp -= JackDamage;
                soundManager.myAudio.PlayOneShot(soundManager.AttackSound);
                TargetPest.Stop = true;
                CreateHit();
            }
        }
    }

    bool IsDoubleAttack()
    {
        if (DoubleAttack == true)
            return true;

        return false;
    }

    internal void PestHitAnim(RL_Anim targetPest)
    {
        TargetPest = targetPest;
        if (TargetPest == null || JumpTrigger == true || CurrentLadder != null)
            return;
        else
        {
            if (TargetPest.CurHp > 0)
            {
                HitBug = true;
            }
            else if (TargetPest.CurHp <= 0)
            {
                HitBug = false;
            }

            TargetTranform.position = transform.position;
            if (TargetPest.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-25, 25, 1);
            }
            else if (TargetPest.transform.position.x < transform.position.x)
            {
                transform.localScale = new Vector3(25, 25, 1);
            }

            if (Input.GetMouseButtonDown(0))
            {
                DoubleAttack = true;
            }
        }
    }

    bool IsJackFloor()
    {
        if (GetFloorXLeft(CurrentFloor) > transform.position.x || GetFloorXRight(CurrentFloor) < transform.position.x)
        {
            return false;
        }
        return true;
    }

    public void EndAttackAnimation()
    {
        DoubleAttack = false;
        HitBug = false;
        Attacking = false;
    }

    public bool IsTargetOn()
    {
        if (TargetFly != null)
            return true;

        if (TargetPest != null)
            return true;

        return false;
    }


    void CreateHit()
    {
        Instantiate(HitEffect);
    }

    void JackCry()
    {
        if (Sm.CurHealth <= 0)
        {
            animator.SetBool("_Cry", true);

            Jack_Cry = +1;
        }
    }


}