using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floor : MonoBehaviour
{

    public Jack_anim JackAnim;
    public int FloorIndex;
    public Ladder UpLadder;
    public Ladder DownLadder;
    public Ladder[] CompareUp;
    public Ladder[] CompareDown;
    private Ladder RestLadder;
    private Ladder RestLadder2;


    public BoxCollider2D FloorCollider;

    private void Awake()
    {
        if (UpLadder)
            UpLadder.DownFloor = this;
        if (DownLadder)
            DownLadder.UpFloor = this;

    }

    private void Update()
    {
        
        if (UpLadder)
            UpLadder.DownFloor = this;
        if (DownLadder)
            DownLadder.UpFloor = this;

        for (int i=0; i<CompareUp.Length; i++)
        {
            if(i== 0)
            {
                RestLadder = CompareUp[i];
            }
            else
            {
                var diffX = Mathf.Abs(JackAnim.transform.position.x - CompareUp[i].transform.position.x);
                if(diffX < Mathf.Abs(JackAnim.transform.position.x - RestLadder.transform.position.x))
                {
                    RestLadder = CompareUp[i];
                }
                   
            }
        }

        UpLadder = RestLadder;
        if (UpLadder)
            UpLadder.DownFloor = this;

        for (int i = 0; i < CompareDown.Length; i++)
        {
            if (i == 0)
            {
                RestLadder2 = CompareDown[i];
            }
            else
            {
                var diffX = Mathf.Abs(JackAnim.transform.position.x - CompareDown[i].transform.position.x);
                if (diffX < Mathf.Abs(JackAnim.transform.position.x - RestLadder2.transform.position.x))
                {
                    RestLadder2 = CompareDown[i];
                }

            }
        }

        DownLadder = RestLadder2;
        if (DownLadder)
            DownLadder.UpFloor = this;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            JackAnim.CurrentFloor = this;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            JackAnim.CurrentFloor = this;
        }
    }
}
