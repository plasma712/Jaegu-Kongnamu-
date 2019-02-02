using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mouseCount : MonoBehaviour {

    public GameManger gm;
    private int mousenum;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        //gm.mouseText.text = str + "마리";
    }

    public void buttondown()
    {
        mousenum += 1;
//gm.beancount.getbean += 1;
    }
}
