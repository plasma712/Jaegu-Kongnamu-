using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exscip : MonoBehaviour {
    public SpriteRenderer sprite;
    public Sprite sp;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        sprite.sprite = sp;
	}
}
