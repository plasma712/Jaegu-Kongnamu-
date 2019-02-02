using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEffect : MonoBehaviour {
    public float limitTime;
    private float DTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        DTime += Time.deltaTime;
        if (DTime > limitTime)
            Destroy(this.gameObject);
	}
}
