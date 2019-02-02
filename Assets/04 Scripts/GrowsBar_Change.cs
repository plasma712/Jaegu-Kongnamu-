using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GrowsBar_Change : MonoBehaviour {
   
    public Sprite[] sprite;
    int Index;
    public ScriptManger sm;
    private float SpeedTime;
    private float limitTime;
	// Use this for initialization
	void Start () {
        limitTime = 3;
	}
	
	// Update is called once per frame
	void Update () {
        ImageChange();
    }

    void ImageChange()
    {
        SpeedTime += Time.deltaTime;
        if (sm.WaterState > 80)
        {
            gameObject.GetComponent<Image>().sprite = sprite[0];
            if(SpeedTime > limitTime)
            {
                sm.HeightSpeed += 0.5f;
                SpeedTime = 0;
            }
        }
        else if (sm.WaterState > 50)
        {
            gameObject.GetComponent<Image>().sprite = sprite[1];
        }
        else if (sm.WaterState > 30)
        {
            gameObject.GetComponent<Image>().sprite = sprite[2];
            if (SpeedTime > limitTime)
            {
                if(sm.HeightSpeed >0)
                    sm.HeightSpeed -= 1;

                SpeedTime = 0;
            }
        }
    }
}
