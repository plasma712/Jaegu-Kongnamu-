using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
    public AudioClip BackGround;
    public AudioClip buttonClickSound;
    public AudioSource myAudio;
    public AudioClip AttackSound;
    public AudioClip JumpingSound;
    public AudioClip PestDieSound;
    public AudioClip CriticalAttackSound;
	// Use this for initialization
	void Start () {
        myAudio = gameObject.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
