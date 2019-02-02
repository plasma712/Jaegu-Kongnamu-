using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundAudio : MonoBehaviour {
    public AudioClip BackAudio;
    private AudioSource myAudio;
	// Use this for initialization
	void Start () {
       myAudio = GetComponent<AudioSource>();
        myAudio.PlayOneShot(BackAudio);
    }
	
	// Update is called once per frame
	void Update () {
	}
}
