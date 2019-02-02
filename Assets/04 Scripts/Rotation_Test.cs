using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation_Test : MonoBehaviour
{
    public float z=0;
    public float x = 0;

    public float speed = 10;
	// Use this for initialization
	void Start ()
    {
		
	}

    // Update is called once per frame
    void Update()
    {
        if (z < 3)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * speed);
            transform.Translate(Vector3.left * Time.deltaTime * 50);

            z += Time.deltaTime;
            x += Time.deltaTime;
            if(x>=12)
            {
                transform.position=new Vector3(-151.0f, 13.0f, -36.2f);
                x = 0;
            }
        }

        else if(z>=3&&z<6)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * -speed);
            transform.Translate(Vector3.left * Time.deltaTime * 50);

            z += Time.deltaTime;
            x += Time.deltaTime;

            if (z>=6)
            {
                z = 0;
            }
            if (x >= 12)
            {
                transform.position = new Vector3(-151.0f, 13.0f, -36.2f);
                x = 0;

            }

        }
    }
}
