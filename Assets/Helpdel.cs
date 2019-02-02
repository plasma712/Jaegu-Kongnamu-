using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Helpdel : MonoBehaviour
{
    public GameObject Help;

    public float k = 0;
	// Update is called once per frame
	void Update ()
    {
        k += Time.deltaTime;

        if(k>4)
        {
            Help.gameObject.SetActive(false);
        }
	}
}
