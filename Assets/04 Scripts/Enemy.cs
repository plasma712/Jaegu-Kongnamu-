using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Jack_anim ja;

    private int WASD;
    private Enemy_Random rand;
    private float damTime;
    public float limitTime;

    public LayerMask m;


    public Enemy_Random Er;

    public RL_Anim RL;

    public FlyAnim Fa;

    public  float num1, num2, num3, num4, num5, num6, num7, num8, num9, num10, num11, num12, num13 = 0;

    void Start()
    {
       Er = GameObject.FindGameObjectWithTag("PestRespawn").GetComponent<Enemy_Random>();

        if (RL.Fly == 0)
        {
            WASD = Random.Range(0, 6);

            if (WASD == 0)
            {
                if (Er.mon6 != 0)
                {
                    Start();
                }
                if (Er.mon6 == 0)
                {
                    GetComponent<Rigidbody2D>().transform.position = new Vector3(-145, -1415, -110);
                    Er.mon6 += 1;
                    num6 += 1;
                }


            }
            else if (WASD == 1)
            {
                if (Er.mon8 != 0)
                {
                    Start();
                }
                if (Er.mon8 == 0)
                {
                    GetComponent<Rigidbody2D>().transform.position = new Vector3(20, -1415, -110);
                    Er.mon8 += 1;
                    num8 += 1;
                }

            }
            else if (WASD == 2)
            {
                if (Er.mon9 != 0)
                {
                    Start();
                }
                if (Er.mon9 == 0)
                {
                    GetComponent<Rigidbody2D>().transform.position = new Vector3(-170, -1535, -110);
                    Er.mon9 += 1;
                    num9 += 1;
                }

            }
            else if (WASD == 3)
            {
                if (Er.mon10 != 0)
                {
                    Start();
                }

                if (Er.mon10 == 0)
                {
                    GetComponent<Rigidbody2D>().transform.position = new Vector3(180, -1535, -110);
                    Er.mon10 += 1;
                    num10 += 1;
                }

            }

            else if (WASD == 4)
            {
                if (Er.mon11 != 0)
                {
                    Start();
                }
                if (Er.mon11 == 0)
                {
                    GetComponent<Rigidbody2D>().transform.position = new Vector3(-100, -1685, -110);
                    Er.mon11 += 1;
                    num11 += 1;
                }

            }
            else if (WASD == 5)
            {
                if (Er.mon12 != 0)
                {
                    Start();
                }
                if (Er.mon12 == 0)
                {
                    GetComponent<Rigidbody2D>().transform.position = new Vector3(60, -1685, -110);
                    Er.mon12 += 1;
                    num12 += 1;
                }

            }
        }

        if (Fa.Fly==1)
        {
            WASD = Random.Range(0, 2);

            if (WASD == 0)
            {
                GetComponent<Rigidbody2D>().transform.position = new Vector3((Random.Range(-220, 200)), -1140, -110);
            }

            if (WASD == 1)
            {
                GetComponent<Rigidbody2D>().transform.position = new Vector3((Random.Range(-220, 200)), -1760, -110);
            }

        }
    }

    void Update()
    {
        
        rand = GameObject.FindGameObjectWithTag("PestRespawn").GetComponent<Enemy_Random>();


        UpdateTime();
        if (rand.destroyPest == true)
            Destroy(gameObject);
    }

    void UpdateTime()
    {
        damTime += Time.deltaTime;

        if (damTime > limitTime)
        {
            damTime = 0;
        }
        
    }


 // void OnTriggerEnter2D(Collider2D collision)
 // { 
 //     if (collision.gameObject.tag == "JumpFoot")
 //     {
 //         if(RL.Fly==0)
 //         {
 //             Start();
 //         }
 //     };
 // }





}
