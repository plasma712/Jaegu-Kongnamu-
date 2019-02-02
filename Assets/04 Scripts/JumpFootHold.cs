using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpFootHold : MonoBehaviour
{
    public Jack_anim Jack;

    public BoxCollider2D boxCollider;
    public float ChangeHeight;
    public float ChangeTotal;

    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Jack.Jump();
            Jack.JumpCompare(boxCollider);
            Jack.ControlJump(ChangeHeight, ChangeTotal);
        }
     }

}
