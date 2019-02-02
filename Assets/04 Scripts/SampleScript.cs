using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScript : MonoBehaviour {
    public GameObject Fly;
    public float delTime;
    public float LimitTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        delTime += Time.deltaTime;

        if(delTime > LimitTime)
        {
            Instantiate(Fly, transform.position, Quaternion.identity);
            delTime = 0;
        }
	}
}
