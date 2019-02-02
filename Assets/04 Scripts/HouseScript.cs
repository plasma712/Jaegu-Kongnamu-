using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HouseScript : MonoBehaviour
{
    public SpriteRenderer HouseSprite;
    public Sprite[] DamageSprite;
    public Sprite UpgradeSprite;
    public ScriptManger sm;
    Animator animator;

    // Use this for initialization
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        sm = GameObject.FindGameObjectWithTag("ScriptManager").GetComponent<ScriptManger>();
        HouseLogic();
        HouseAnim();
        HouseSprite.sprite = UpgradeSprite;
    }

    void HouseLogic()
    {
       // HouseSprite.sprite = UpgradeSprite[1];
        //if (sm.CurHealth <= sm.MaxHealth / 2)
        //{
        //    if (DamageSprite == null)
        //        return;

        //    HouseSprite.sprite = DamageSprite[sm.SkillTwoLevel];
        //}
        //else
        //{
        //    HouseSprite.sprite = UpgradeSprite[sm.SkillTwoLevel];
        //}
    }

    void HouseAnim()
    {
        if (sm.CurHealth <= 0)
        {
            HouseSprite.sprite = null;
            animator.SetInteger("HouseOver", sm.SkillTwoLevel+1);
        }
    }
}
