using UnityEngine;
using System.Collections;

public class FireController : MonoBehaviour
{

    public GameObject bullet;
    public Transform firePos;

    public float time = 0;
    public float tag_time = 0;

    public float delay_bullet = 0;


    public bool Shooting;
    // Use this for initialization
    void Start()
    {
        Shooting = false;
    }

    // Update is called once per frame
    void Update()
    {
        //    Fire();
        //    TagTime();

    }
    void Fire()
    {
        //  if (Shooting == true)
        //  {
        //      if (time > delay_bullet)
        //      {
        //          CreateBullet();
        //
        //          time = 0;
        //          Shooting = false;
        //      }
        //  }

        CreateBullet();

    }

    // void TagTime()
    // {
    //     if(tag_time==1)
    //     {
    //         time += Time.deltaTime;
    //     }
    //
    // }

    void CreateBullet()
    {
        Instantiate(bullet, firePos.position, firePos.rotation);
    }


    void OnTriggerEnter2D(Collider2D col)
    {

        if (col.gameObject.tag == "House")
        {
            tag_time = 1;

            Debug.Log("충돌처리 완료");
        }
    }


}
