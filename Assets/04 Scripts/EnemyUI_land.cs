using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI_land : MonoBehaviour
{
    public RL_Anim RL;
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
        Amount = 1.0f * ((float)RL.CurHp / (float)RL.MaxHp);
        HelthBar.fillAmount = Amount;
    }
}
