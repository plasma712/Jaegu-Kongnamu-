using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class touchtest : MonoBehaviour {
    public ScriptManger sm;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount>0 || Input.GetKeyDown(KeyCode.Mouse0))
        {
            sm.BeansCount += sm.haveBeans;
        }
	}
}
