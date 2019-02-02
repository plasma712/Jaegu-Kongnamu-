using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpCollider : MonoBehaviour
{
    public Jack_anim Jack;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Jack.Jump();
        Debug.Log("들어감");
    }
}
