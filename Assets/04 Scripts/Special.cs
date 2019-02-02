using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Special : MonoBehaviour
{
    public float Enemy_RespawnTime;

    private static Special instance;
    public ScriptManger sm;

    public GameObject Bee;


    void Awake()
    {
        instance = this;

    }

    void Update()
    {

        if (sm.EnemySpot_HeightMount >= 100&&sm.EnemySpot_HeightMount<107)
        {

            Enemy_RespawnTime += Time.deltaTime;

            if (Enemy_RespawnTime > 6)
            {
                CreateEnemy();
                Enemy_RespawnTime = 0;
            }
        }
        if(sm.EnemySpot_HeightMount>=200 &&sm.EnemySpot_HeightMount<207)
        {
            Enemy_RespawnTime += Time.deltaTime;

            if (Enemy_RespawnTime > 6)
            {
                CreateEnemy();
                Enemy_RespawnTime = 0;
            }
        }
    }

    void CreateEnemy()
    {
        Instantiate(Bee);
    }

    public static void Cancel()
    {
        instance.CancelInvoke();
    }

}
