using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeTouch : MonoBehaviour {
    public ScriptManger sm;
    // Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Mouse0))
        {
            if(Time.timeScale == 1)
            sm.BeansCount += sm.haveBeans;
            //Vector2 vec2 = Input.GetTouch(0).position;
            //Vector3 vec3 = new Vector3(vec2.x, vec2.y, 0.0f);
        }
	}

}
