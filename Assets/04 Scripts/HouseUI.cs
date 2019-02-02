using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseUI : MonoBehaviour {

    public ScriptManger Sm;
    public Image HelthBar;
    //public Image HelthBarShadow;
    public float Amount;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Amount = 1.0f * ((float)Sm.CurHealth / (float)Sm.MaxHealth);
        HelthBar.fillAmount = Amount;
    }
}
