using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_Pest_rand : MonoBehaviour
{
    int Number;     //랜덤생성을위해

    void Start()
    {
        Number = Random.Range(0, 3);

        if(Number==0)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector3(-105, -1680, -110);

        }

        if (Number == 1)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector3(-60, -1280, -110);

        }

        if (Number == 2)
        {
            GetComponent<Rigidbody2D>().transform.position = new Vector3(-40, -1800, -110);

        }


    }


}
