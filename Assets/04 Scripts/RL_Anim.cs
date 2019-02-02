using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RL_Anim : MonoBehaviour
{
    public float Getbeans;
    public float movePower = 1f;

    public bool Stop;
    private float StopTime;
    Animator animator;
    Vector3 movement;
    int movementFlag = 0;
    private Jack_anim JackAnim;
    public BoxCollider2D BoxCollider;
    public GameObject SlidePrePabs;
    public float DelTime;
    public int CurHp;
    public int MaxHp;
    ScriptManger sm;

    public int Fly = 0;

    bool Die;
    bool NMove;


    public Enemy_Random ER;
    public GameObject House;
    public Enemy enemy;

    public float Scale = 25;

    
    public Jangsoo_Spot Jang_soo;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();
        JackAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Jack_anim>();
        Jang_soo = GameObject.FindGameObjectWithTag("Jangsoo_Spot").GetComponent<Jangsoo_Spot>();

        StartCoroutine("ChangeMovement");
        Die = false;
        NMove = false;
        CurHp = MaxHp*Jang_soo.Hp_maxPlus;
        sm = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<ScriptManger>();
        ER = GameObject.FindGameObjectWithTag("PestRespawn").GetComponent<Enemy_Random>();
        House = GameObject.FindGameObjectWithTag("House");

    }

    private void Update()
    {

        PestHelath();
        ChaseMousePosition();
        if (Fly == 0)
        {
            if (NMove == false)
            {
                if (Die == false)
                {
                    Move();
                }
            }
        }
    }

    void Move()
    {
        if (sm.CurHealth <= 0)
            return;
        
        if (Stop == true)
        {
            StopTime += Time.deltaTime;
            if (StopTime > 1.0f)
            {
                Stop = false;
                StopTime = 0;
            }
            return;
        }

        Vector3 moveVelocity = Vector3.zero;
        if (Fly == 0)
        {
            if (movementFlag == 1)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(Scale, Scale, 1);
            }

            else if (movementFlag == 2)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-Scale, Scale, 1);
            }
        }
        // if (Fly == 1)
        // {
        //     if (movementFlag == 1)
        //     {
        //         int UpDown = Random.Range(0, 2);
        //         if (UpDown == 0)
        //         {
        //             moveVelocity = Vector3.left;
        //
        //         }
        //         else
        //         {
        //             moveVelocity = Vector3.up * 2;
        //
        //
        //         }
        //         transform.localScale = new Vector3(25, 25, 1);
        //     }
        //
        //     else if (movementFlag == 2)
        //     {
        //         int UpDown = Random.Range(0, 2);
        //         if (UpDown == 0)
        //         {
        //             moveVelocity = Vector3.right;
        //
        //         }
        //         else
        //         {
        //             moveVelocity = Vector3.up * 2;
        //
        //         }
        //
        //         transform.localScale = new Vector3(-25, 25, 1);
        //     }
        //
        // }


        transform.position += moveVelocity * movePower * Time.deltaTime;
    }

    void PestHelath()
    {
        if (Fly == 0)
        {
            if (CurHp <= 0)
            {
                animator.SetBool("_Hitting", true);
                Destroy(this.gameObject, 1.0f);
                Die = true;

                if(Jang_soo.JangSoo_Num== 1)
                {
                    sm.EnemySpot_HeightMount = 0;

                    Jang_soo.JangSoo_Num = 0;
                    Jang_soo.Enemy_RespawnTime = 0;
                }

                if (Die == true && DelTime == 0)
                {
                    Vector3 vec3 = new Vector3(transform.position.x + 10, transform.position.y, transform.position.z);
                    Instantiate(SlidePrePabs, vec3, Quaternion.identity);
                    sm.PlusBeans(Getbeans);

                    ER.List_Enemy -= 1;

                    if(enemy.num1==1)
                    {
                        ER.mon1 = 0;
                    }
                    if (enemy.num2 == 1)
                    {
                        ER.mon2 = 0;
                    }
                    if (enemy.num3 == 1)
                    {
                        ER.mon3 = 0;
                    }
                    if (enemy.num3 == 1)
                    {
                        ER.mon3 = 0;
                    }
                    if (enemy.num4 == 1)
                    {
                        ER.mon4 = 0;
                    }
                    if (enemy.num5 == 1)
                    {
                        ER.mon5 = 0;
                    }
                    if (enemy.num6 == 1)
                    {
                        ER.mon6 = 0;
                    }
                    if (enemy.num7 == 1)
                    {
                        ER.mon7 = 0;
                    }
                    if (enemy.num8 == 1)
                    {
                        ER.mon8 = 0;
                    }
                    if (enemy.num9 == 1)
                    {
                        ER.mon9 = 0;
                    }
                    if (enemy.num10 == 1)
                    {
                        ER.mon10 = 0;
                    }
                    if (enemy.num11 == 1)
                    {
                        ER.mon11 = 0;
                    }
                    if (enemy.num12 == 1)
                    {
                        ER.mon12 = 0;
                    }
                    if (enemy.num13 == 1)
                    {
                        ER.mon13 = 0;
                    }

                }
                DelTime += Time.deltaTime;
            }
        }
    }

    IEnumerator ChangeMovement()
    {
        movementFlag = Random.Range(0, 3);
        yield return new WaitForSeconds(3f);
        StartCoroutine("ChangeMovement");
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Vector3 moveVelocity = Vector3.zero;

        if (col.gameObject.tag == "Tree")
        {
            if (movementFlag == 1)
            {
                moveVelocity = Vector3.right;
                transform.localScale = new Vector3(-Scale, Scale, 1);

                movementFlag = 2;
            }

            else if (movementFlag == 2)
            {
                moveVelocity = Vector3.left;
                transform.localScale = new Vector3(Scale, Scale, 1);

                movementFlag = 1;
            }
        }

        if (Fly == 0)
        {
            if (col.gameObject.tag == "Gap")
            {
                if (movementFlag == 1)
                {
                    moveVelocity = Vector3.right;
                    transform.localScale = new Vector3(-Scale, Scale, 1);

                    movementFlag = 2;
                }

                else if (movementFlag == 2)
                {
                    moveVelocity = Vector3.left;
                    transform.localScale = new Vector3(Scale, Scale, 1);

                    movementFlag = 1;
                }

            }

        }
        if (col.gameObject.tag == "House")
        {
            animator.SetBool("_Attack", true);
            NMove = true;
            Debug.Log("어택");


            if (transform.position.x > House.transform.position.x)
            {
                transform.localScale = new Vector3(Scale, Scale, 1);
            }
            if (transform.position.x < House.transform.position.x)
            {
                transform.localScale = new Vector3(-Scale, Scale, 1);
            }
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
            if (PestPositionX - BoxCollider.size.x * Mathf.Abs(transform.lossyScale.x) < JackAnim.transform.position.x &&
               PestPositionX + BoxCollider.size.x * Mathf.Abs(transform.lossyScale.x) > JackAnim.transform.position.x &&
               PestPositionY - BoxCollider.size.y * Mathf.Abs(transform.lossyScale.y) / 2 < JackAnim.transform.position.y &&
               PestPositionY + BoxCollider.size.y * Mathf.Abs(transform.lossyScale.y) > JackAnim.transform.position.y)
            {
                JackAnim.PestHitAnim(this);
            }
        }
        //else
        //{
        //    JackAnim.PestHitAnim(null);
        //}
    }
}


