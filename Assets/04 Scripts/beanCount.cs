using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beanCount : MonoBehaviour {

    public GameManger gm;
    public int bean;
    public float beanSpeed;
    public int getbean;
    public float time;

    //이미지
    public GameObject Image1;
    public GameObject Image2;

    // Use this for initialization
    void Start () {
  
	}
	
	// Update is called once per frame
	void Update () {
        time += Time.deltaTime;
        if (time > 0.5f)
        {
            bean += getbean;
            time = 0.0f;
        }

        if(bean / 100%2==1) // bean의 특정값에 따라 이미지변경
        {
            Image1.gameObject.SetActive(false);
            Image2.gameObject.SetActive(true);

        }
        if (bean/100%2==0)
        {
            Image1.gameObject.SetActive(true);
            Image2.gameObject.SetActive(false);
        }
       // string str = string.Format("{0:f0}", bean);
        
       // gm.beanText.text = str + "개";
	}

    public void ClickBuy()
    {
        int buyCost = 100;
        if (bean < 100)
            return;

        bean -= buyCost;
    }
}
