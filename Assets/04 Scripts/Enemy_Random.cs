using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Random : MonoBehaviour
{
    public GameObject PestEliminate;
   // public GameObject ProtectEffect;
    private static Enemy_Random instance;
    public ScriptManger sm;

    public bool destroyPest;
    private float destroyTime;
    public float limitTime;
    private float Enemy_RespawnTime;

    //벌레들 랜덤생성을 위해
    public GameObject Pest;
    public GameObject Apihid;
    public GameObject Moth;
    public GameObject Bee;
    public GameObject Spider;
    public GameObject LadyBird;

    public GameObject Cicada;
    private Jack_anim JackAnim;

    int Number;     //랜덤생성을위해


    public float List_Enemy = 0;//제한하기 위해서...

    public float mon1, mon2, mon3, mon4, mon5, mon6, mon7, mon8, mon9, mon10, mon11, mon12, mon13 = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
       // InvokeRepeating("CreateEnemy", 5.0f, sm.GetPest_RespawnTime()); // 함수이름/함수가 불리는 주기/ 반복 호출 회수
        destroyPest = false;
    }

    void Update()
    {
        JackAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Jack_anim>();
        if (List_Enemy < 10)
        {
            Enemy_RespawnTime += Time.deltaTime;


            //if (Enemy_RespawnTime > sm.GetPest_RespawnTime())
            if (Enemy_RespawnTime > 5)
            {
                if (mon6 == 0 || mon8 == 0 || mon9 == 0 || mon10 == 0 || mon11 == 0 || mon12 == 0)
                {
                    CreateEnemy();
                    Enemy_RespawnTime = 0;

                    List_Enemy += 1;
                }
                
            }
        }

        if (destroyPest == true)
        {
            if(destroyTime < limitTime)
                destroyTime += Time.deltaTime;
            else
            {
                destroyTime = 0.0f;
                destroyPest = false;
            }

            List_Enemy = 0;
        }

    }

    void CreateEnemy()
    {
        if (destroyPest == false)
        {
            Number = Random.Range(0, 100);

            if (sm.EnemySpot_HeightMount < 10)
            {

            }

            if (sm.EnemySpot_HeightMount >= 10 && sm.EnemySpot_HeightMount < 50)
            {
                if(Number>0 &&Number<50)
                {
                    Instantiate(Apihid);
                }
                if(Number>=50)
                {
                    Instantiate(Moth);
                }
            }

            if (sm.EnemySpot_HeightMount >= 50 && sm.EnemySpot_HeightMount < 100)
            {
                if (Number > 0 && Number < 25)
                {
                    Instantiate(Apihid);
                }
                if (Number >= 25&&Number<50)
                {
                    Instantiate(Moth);
                }
                if(Number>=50)
                {
                    Instantiate(LadyBird);
                }

            }

            if(sm.EnemySpot_HeightMount >= 100&&sm.EnemySpot_HeightMount < 110)
            {

            }

            if (sm.EnemySpot_HeightMount >= 110 && sm.EnemySpot_HeightMount < 150)
            {
                if (Number > 0 && Number < 25)
                {
                    Instantiate(Apihid);
                }
                if (Number >= 25 && Number < 50)
                {
                    Instantiate(Moth);
                }
                if (Number >= 50)
                {
                    Instantiate(Spider);
                }

            }

            if (sm.EnemySpot_HeightMount >= 150 && sm.EnemySpot_HeightMount < 200)
            {
                if (Number > 0 && Number < 25)
                {
                    Instantiate(LadyBird);
                }
                if (Number >= 25 && Number < 50)
                {
                    Instantiate(Moth);
                }
                if (Number >= 50)
                {
                    Instantiate(Spider);
                }

            }

            if (sm.EnemySpot_HeightMount >= 200 && sm.EnemySpot_HeightMount < 210)
            {

            }

            if (sm.EnemySpot_HeightMount >= 210 && sm.EnemySpot_HeightMount < 250)
            {
                if (Number > 0 && Number < 25)
                {
                    Instantiate(Moth);
                }
                if (Number >= 25 && Number < 50)
                {
                    Instantiate(Spider);
                }
                if (Number >= 50)
                {
                    Instantiate(Cicada);
                }

            }

            if (sm.EnemySpot_HeightMount >= 250 && sm.EnemySpot_HeightMount < 300)
            {
                if (Number > 0 && Number < 25)
                {
                    Instantiate(LadyBird);
                }
                if (Number >= 25 && Number < 50)
                {
                    Instantiate(Spider);
                }
                if (Number >= 50)
                {
                    Instantiate(Cicada);
                }


            }



        }
    }

    public static void Cancel()
    {
        instance.CancelInvoke();
    }

    public void PestClick()
    {
        sm.ButtonActive = true;
        if (sm.BeansCount < sm.SkillProtectPrice)
            return;

        Instantiate(PestEliminate, PestEliminate.transform.position, Quaternion.identity);
        sm.MinusBeans(sm.SkillProtectPrice);
        destroyPest = true;
        sm.SkillProtectPrice += sm.SkillProtectPrice / 5;
        JackAnim.TargetTranform.position = JackAnim.transform.position;

        mon6 = 0;
        mon8 = 0;
        mon9 = 0;
        mon10 = 0; 
        mon11 = 0;
        mon12 = 0;
    }
}
