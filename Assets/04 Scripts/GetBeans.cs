using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GetBeans : MonoBehaviour {

    public class BText : GetBeans
    {
        public Vector3 vec;
        
    }

    public int beans;
    public TextMeshProUGUI getBeans;
 
    float moveSpeed;
    float alpha = 1;
    float DelTime;
    int Index = 0;
    ScriptManger sm;

	// Use this for initialization
	void Start () {
        
        sm = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<ScriptManger>();
        beans = sm.haveBeans;
             
	}
	
	// Update is called once per frame
	void Update () {
        beanText();
        move();
        des();

	}

    void beanText()
    {
        getBeans.text ="+" + beans;
    }

    void move()
    {
        if (Time.timeScale == 1)
        {
            if (moveSpeed < 2.0f)
            {
                moveSpeed += 0.05f;
                Vector3 vec = new Vector3(transform.position.x + 0.5f, transform.position.y + moveSpeed, transform.position.z);
                transform.position = vec;
            }
            else
            {
                if (alpha > 0)
                {
                    alpha -= Time.deltaTime;
                    getBeans.color = new Color(255, 255, 255, alpha);
                }
            }
        }

    }

    void des()
    {
        DelTime += Time.deltaTime;

        if (DelTime > 2.0f)
        {
            getBeans.color = new Color(255, 255, 255, 1);
            Index += 1;
            moveSpeed = 0.0f;
            DelTime = 0;
            Destroy(this.gameObject);
        }
    }

}
