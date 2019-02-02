using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree_Dry : MonoBehaviour
{
    public ScriptManger Sm;

    Animator animator;

    void Start()
    {
        animator = gameObject.GetComponentInChildren<Animator>();

    }

    void FixedUpdate()
    {
        Dry();
    }

    void Dry()
    {
        if(Sm.WaterState<50)
        {
            animator.SetBool("_Dry", true);
        }
        else
        {
            animator.SetBool("_Dry", false);
        }
    }
}
