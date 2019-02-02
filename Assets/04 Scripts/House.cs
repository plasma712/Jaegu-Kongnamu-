using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class House : MonoBehaviour {

    public SpriteRenderer HouseSprite;
    public Sprite[] UpgradeSprite;
    public Sprite[] DamageSprite;
    public ScriptManger Sm;
    private Animator Anim;
    private void Start()
    {
        Anim = gameObject.GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update () {

        if (Sm.CurHealth <= 0)
        {
            HouseSprite.sprite = null;
            Anim.SetInteger("UpgadeNum", Sm.SkillTwoLevel + 1);
        }
        else
        {
            if (Sm.CurHealth > Sm.MaxHealth / 2)
            {
                HouseSprite.sprite = UpgradeSprite[Sm.SkillTwoLevel];
            }
            else
            {
                HouseSprite.sprite = DamageSprite[Sm.SkillTwoLevel];
            }
        }
	}
}
