using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Manger : MonoBehaviour
{
    public ScriptManger Sm;


    public GameObject Image1;
    public GameObject Image3;
    public GameObject Image4;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (Sm.HeightMount>90000 &&Sm.HeightMount<100000)
            {
                Image1.gameObject.SetActive(false);

            }
            if (Sm.HeightMount > 100000 &&Sm.HeightMount< 4500000)
            {

            }

           if (Sm.HeightMount > 4500000 && Sm.HeightMount < 5000000)
           {
            Image3.gameObject.SetActive(false);

           }


        if (Sm.HeightMount > 5000000)
        {
            Image4.gameObject.SetActive(true);
        }
        
    }
}