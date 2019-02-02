using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Pest : MonoBehaviour
{
    public float Enemy_RespawnTime;

    private static Bonus_Pest instance;
    public ScriptManger sm;

   

    public GameObject RedPest;


    void Awake()
    {
        instance = this;

    }

    void Update()
    {

        if (sm.EnemySpot_HeightMount >= 300)
        {

            Enemy_RespawnTime += Time.deltaTime;

            if (Enemy_RespawnTime > 10)
            {
                CreateEnemy();
                Enemy_RespawnTime = 0;
            }
        }
    }

    void CreateEnemy()
    {
        Instantiate(RedPest);
    }

    public static void Cancel()
    {
        instance.CancelInvoke();
    }

}
