using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class backAudio : MonoBehaviour {
    public SoundManager SoundM;
    private AudioSource myAudio;
	// Use this for initialization
	void Start () {
        myAudio = gameObject.GetComponent<AudioSource>();
        myAudio.PlayOneShot(SoundM.BackGround);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
