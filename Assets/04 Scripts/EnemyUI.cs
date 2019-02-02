using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour {
    public FlyAnim flyAnim;
    public Image HelthBar;
   //public Image HelthBarShadow;
    public float Amount;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        Amount = 1.0f * ((float)flyAnim.CurHp / (float)flyAnim.MaxHp);
        HelthBar.fillAmount = Amount;
	}
}
