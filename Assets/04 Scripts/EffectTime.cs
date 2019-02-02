using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectTime : MonoBehaviour {
    private float time;
    public float effectTime;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;

        if(time > effectTime)
        {
            Destroy(this.gameObject);
        }

	}
}
