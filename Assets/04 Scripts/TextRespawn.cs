using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextRespawn : MonoBehaviour {

    float RespawnTime;
    public GameObject housetext;
    public GameObject Canvas;
    public ScriptManger sm;
    public float RespawnSpeed;
    private float Speed;
    GameObject myText;
    GetBeans get;
	// Use this for initialization
	void Start () {
        Speed = RespawnSpeed;
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update () {
        
        //RespawnTime += Time.deltaTime;
        //Speed = RespawnSpeed + (sm.MaxHealth / sm.CurHealth) -1; 
        
        //if (RespawnTime > Speed)
        //{
        //    RespawnTime = 0.0f;
        //    myText = Instantiate(housetext);
        //    myText.transform.SetParent(Canvas.transform, false);
        //    sm.PlusBeans(sm.haveBeans);
        //} 
	}
}
