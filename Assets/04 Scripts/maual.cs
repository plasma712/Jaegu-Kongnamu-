using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class maual : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void ClickMenual()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    public void Cancel()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
