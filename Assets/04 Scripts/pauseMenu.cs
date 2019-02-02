using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseMenu : MonoBehaviour {
    private bool act;

	// Use this for initialization
	void Start () {
        act = false;
        gameObject.SetActive(act);
	}
	
	// Update is called once per frame
	void Update () {
    }

    public void active()
    {
        act = !act;
        gameObject.SetActive(act);
    }
}
