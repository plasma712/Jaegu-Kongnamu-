using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jangsoo_Spot : MonoBehaviour
{
    public float Enemy_RespawnTime;

    private static Jangsoo_Spot instance;
    public ScriptManger sm;

    public Enemy_Random Er;

    public GameObject JangSoo;

    public RL_Anim RL;

    public int Hp_maxPlus = 1;

    public float JangSoo_Num = 0;


    void Awake()
    {
        instance = this;

    }

    void Update()
    {

        if (sm.EnemySpot_HeightMount>=300)
        {

            Er.destroyPest = true;

            Enemy_RespawnTime += Time.deltaTime;

            if (Enemy_RespawnTime > 10)
            {
                if (JangSoo_Num == 0)
                {
                    CreateEnemy();
                    JangSoo_Num = 1;
                    Hp_maxPlus += 1;
                }
            }
        }
    }

    void CreateEnemy()
    {
        Instantiate(JangSoo);
    }

    public static void Cancel()
    {
        instance.CancelInvoke();
    }

}
