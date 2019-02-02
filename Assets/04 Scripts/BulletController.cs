using UnityEngine;
using System.Collections;

public class BulletController : MonoBehaviour
{

    public float speed = 30f;
    Animator animator;

    //    public GameObject player;

    public FireController player;


    bool bullet_Destory;

    public ScriptManger Sm;

    public float damage;

    // Use this for initialization
    void Start()
    {
        //   Destroy(this.gameObject, 2f);    // delete itself
        player = GameObject.FindWithTag("House").GetComponent<FireController>();
        bullet_Destory = false;
        animator = gameObject.GetComponentInChildren<Animator>();
        Sm = GameObject.FindWithTag("ScriptManager").GetComponent<ScriptManger>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Sm.CurHealth <= 0)
            return;

        if (bullet_Destory == false)
        {

            Vector2 relativePos = player.transform.position - transform.position;
            float angle = Mathf.Atan2(relativePos.y, relativePos.x) * Mathf.Rad2Deg;
            transform.localRotation = Quaternion.Euler(0, 0, angle - 90);
            transform.Translate(transform.up * speed * Time.deltaTime, Space.World);

        }

        if (bullet_Destory == true)
        {
            animator.SetBool("_Hitting", true);

        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "House")
        {
            Destroy(this.gameObject, 1.0f);
            Debug.Log("총알충돌");
            Sm.MinusHealth(damage);

            bullet_Destory = true;

        }

    }




}
