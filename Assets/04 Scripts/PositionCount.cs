using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionCount : MonoBehaviour {

    public GameManger gm;
    public float CusPos;
    public int speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CusPos += Time.deltaTime * speed;
        //string str = string.Format("{0:f0}", CusPos);

       // gm.positionText.text = str + "M";

    }
}
