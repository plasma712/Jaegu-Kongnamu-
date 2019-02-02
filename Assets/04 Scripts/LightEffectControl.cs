using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightEffectControl : MonoBehaviour {
    public GameObject[] go;
    public GameObject Effect;
    GameObject EffectObject;
    public SoundManager SoundM;
    //public GameObject Canvas;
    int i = 0;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CreateEffectCharactor()
    {
        i = 0;
        EffectObject = Instantiate(Effect);
        EffectObject.transform.SetParent(go[i].transform, false);
        SoundM.myAudio.PlayOneShot(SoundM.buttonClickSound);
    }

    public void CreateEffectHouse()
    {
        i = 1;
        EffectObject = Instantiate(Effect);
        EffectObject.transform.SetParent(go[i].transform, false);
        SoundM.myAudio.PlayOneShot(SoundM.buttonClickSound);
    }

    public void CreateEffectShop()
    {
        i = 2;
        EffectObject = Instantiate(Effect);
        EffectObject.transform.SetParent(go[i].transform, false);
        SoundM.myAudio.PlayOneShot(SoundM.buttonClickSound);
    }

    public void CreateEffectMenue()
    {
        i = 3;
        EffectObject = Instantiate(Effect);
        EffectObject.transform.SetParent(go[i].transform, false);
        SoundM.myAudio.PlayOneShot(SoundM.buttonClickSound);
    }
}
