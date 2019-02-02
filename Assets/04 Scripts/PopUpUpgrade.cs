using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpUpgrade : MonoBehaviour
{
    public ScriptManger sm;
    public GameManger gm;
    public Image Befroe;
    public Image After;
    public Sprite[] ChangeImage;
    private bool SkillOneSet;
    private bool SkillTwoSet;
    private bool SkillThreeSet;
    private bool SkillFourSet;

    // Use this for initialization
    void Start()
    {
        SkillOneSet = false;
        SkillTwoSet = false;
        SkillThreeSet = false;
        SkillFourSet = false;
    }

    // Update is called once per frame
    void Update()
    {
        UpdateText();
    }

    private void Awake()
    {
    }

    public void PopupCancel()
    { 
        gameObject.SetActive(false);
        gm.PopUpUpgradeButton.onClick.RemoveAllListeners();
        ResetSkill();
    }

    public void ClickPopUpSkillOneUpgrade() // 콩 수확하기
    {
        Stop();
        Befroe.sprite = ChangeImage[0];
        After.sprite = ChangeImage[0];
        gm.PopUpUpgradeButton.onClick.AddListener(sm.ClickSkillOne);

        SkillOneSet = true;

        string str = string.Format("{0:f0}", sm.haveBeans);
        string str2 = string.Format("{0:f0}", sm.SkillOneLevel + 1);
        sm.BefroeText.text = "콩 수확\n" + "레벨" + str2;
        sm.BefroeAccount.text = "콩 수확 갯수 " + "+" + str;

        string str5 = string.Format("{0:f0}", sm.SkillOnePrice);
        sm.BeanPrice.text = str5;

        string str3 = string.Format("{0:f0}", sm.haveBeans + 1);
        string str4 = string.Format("{0:f0}", sm.SkillOneLevel + 2);
        sm.AfterText.text = "콩 수확\n" + "레벨" + str4;
        sm.AfterAccount.text = "콩 수확 갯수 " + "+" + str3;
    }

    public void ClickPopUpSkillTwoUpgrade() // 단단해지기
    {
        Stop();
        Befroe.sprite = ChangeImage[1];
        After.sprite = ChangeImage[1];
        gm.PopUpUpgradeButton.onClick.AddListener(sm.ClickSkillTwo);

        SkillTwoSet = true;

        string str = string.Format("{0:f0}", sm.MaxHealth);
        string str2 = string.Format("{0:f0}", sm.SkillTwoLevel + 1);
        sm.BefroeText.text = "단단해지기\n" + "레벨" + str2;
        sm.BefroeAccount.text = "Max체력 " + "+" + str;

        string str5 = string.Format("{0:f0}", sm.SkillTwoPrice);
        sm.BeanPrice.text = str5;

        string str3 = string.Format("{0:f0}", sm.MaxHealth + 50);
        string str4 = string.Format("{0:f0}", sm.SkillTwoLevel + 2);
        sm.AfterText.text = "단단해지기\n" + "레벨" + str4;
        sm.AfterAccount.text = "Max체력 " + "+" + str3;
    }

    public void ClickPopUpSkillTreeUpgrade() // 해충잡기
    {
        Stop();
        Befroe.sprite = ChangeImage[2];
        After.sprite = ChangeImage[2];
        gm.PopUpUpgradeButton.onClick.AddListener(sm.ClickSkillThree);

        SkillThreeSet = true;

        string str = string.Format("{0:f0}", sm.PestKill);
        string str2 = string.Format("{0:f0}", sm.SkillThreeLevel + 1);
        sm.BefroeText.text = "해충잡기\n" + "레벨" + str2;
        sm.BefroeAccount.text = "해충 잡는 횟수 " + "+" + str;

        string str5 = string.Format("{0:f0}", sm.SkillThreePrice);
        sm.BeanPrice.text = str5;

        string str3 = string.Format("{0:f0}", sm.PestKill + 1);
        string str4 = string.Format("{0:f0}", sm.SkillThreeLevel + 2);
        sm.AfterText.text = "해충잡기\n" + "레벨" + str4;
        sm.AfterAccount.text = "해충 잡는 횟수 " + "+" + str3;
    }

    public void ClickPopUpSkillFourUpgrade() //수분 주기
    {
        Stop();
        Befroe.sprite = ChangeImage[3];
        After.sprite = ChangeImage[3];

        gm.PopUpUpgradeButton.onClick.AddListener(sm.ClickSkillFour);

        SkillFourSet = true;

        string str = string.Format("{0:f0}", sm.WaterSpeedUp);
        string str2 = string.Format("{0:f0}", sm.SkillFourLevel + 1);
        sm.BefroeText.text = "물주기\n" + "레벨" + str2;
        sm.BefroeAccount.text = "물 주는 양 " + "+" + str + "%";

        string str5 = string.Format("{0:f0}", sm.SkillFourPrice);
        sm.BeanPrice.text = str5;

        string str3 = string.Format("{0:f1}", sm.WaterSpeedUp + 0.1f);
        string str4 = string.Format("{0:f1}", sm.SkillFourLevel + 2);
        sm.AfterText.text = "물주기\n" + "레벨" + str4;
        sm.AfterAccount.text = "물 주는 양 " + "+" + str3 + "%";
    }

    void Stop()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
    }

    void UpdateText()
    {
        if (SkillOneSet == true)
        {
            string str = string.Format("{0:f0}", sm.haveBeans);
            string str2 = string.Format("{0:f0}", sm.SkillOneLevel + 1);
            sm.BefroeText.text = "콩 수확\n" + "레벨" + str2;
            sm.BefroeAccount.text = "콩 수확 갯수 " + "+" + str;

            if (sm.SkillOnePrice > (int)sm.BeansCount)
                sm.BeanPrice.color = new Color(255, 0, 0);
            else
                sm.BeanPrice.color = new Color(255, 255, 255);

            string str5 = string.Format("{0:f0}", sm.SkillOnePrice);
            sm.BeanPrice.text = str5;


            string str3 = string.Format("{0:f0}", sm.haveBeans + 1);
            string str4 = string.Format("{0:f0}", sm.SkillOneLevel + 2);
            sm.AfterText.text = "콩 수확\n" + "레벨" + str4;
            sm.AfterAccount.text = "콩 수확 갯수 " + "+" + str3;
        }
        else if (SkillTwoSet == true)
        {
            string str = string.Format("{0:f0}", sm.MaxHealth);
            string str2 = string.Format("{0:f0}", sm.SkillTwoLevel + 1);
            sm.BefroeText.text = "단단해지기\n" + "레벨" + str2;
            sm.BefroeAccount.text = "Max체력 " + "+" + str;

            if (sm.SkillTwoPrice > (int)sm.BeansCount)
                sm.BeanPrice.color = new Color(255, 0, 0);
            else
                sm.BeanPrice.color = new Color(255, 255, 255);

            string str5 = string.Format("{0:f0}", sm.SkillTwoPrice);
            sm.BeanPrice.text = str5;

            string str3 = string.Format("{0:f0}", sm.MaxHealth + 50);
            string str4 = string.Format("{0:f0}", sm.SkillTwoLevel + 2);
            sm.AfterText.text = "단단해지기\n" + "레벨" + str4;
            sm.AfterAccount.text = "Max체력 " + "+" + str3;
        }
        else if (SkillThreeSet == true)
        {
            string str = string.Format("{0:f0}", sm.PestKill);
            string str2 = string.Format("{0:f0}", sm.SkillThreeLevel + 1);
            sm.BefroeText.text = "해충잡기\n" + "레벨" + str2;
            sm.BefroeAccount.text = "해충 잡는 횟수 " + "+" + str;

            if (sm.SkillThreePrice > (int)sm.BeansCount)
                sm.BeanPrice.color = new Color(255, 0, 0);
            else
                sm.BeanPrice.color = new Color(255, 255, 255);

            string str5 = string.Format("{0:f0}", sm.SkillThreePrice);
            sm.BeanPrice.text = str5;

            string str3 = string.Format("{0:f0}", sm.PestKill + 1);
            string str4 = string.Format("{0:f0}", sm.SkillThreeLevel + 2);
            sm.AfterText.text = "해충잡기\n" + "레벨" + str4;
            sm.AfterAccount.text = "해충 잡는 횟수 " + "+" + str3;
        }
        else if (SkillFourSet == true)
        {
            string str = string.Format("{0:f1}", sm.WaterSpeedUp);
            string str2 = string.Format("{0:f0}", sm.SkillFourLevel + 1);
            sm.BefroeText.text = "물주기\n" + "레벨" + str2;
            sm.BefroeAccount.text = "물 주는 양 " + "+" + str + "%";

            if (sm.SkillFourPrice > (int)sm.BeansCount)
                sm.BeanPrice.color = new Color(255, 0, 0);
            else
                sm.BeanPrice.color = new Color(255, 255, 255);

            string str5 = string.Format("{0:f0}", sm.SkillFourPrice);
            sm.BeanPrice.text = str5;

            string str3 = string.Format("{0:f1}", sm.WaterSpeedUp + 0.1f);
            string str4 = string.Format("{0:f0}", sm.SkillFourLevel + 2);
            sm.AfterText.text = "물주기\n" + "레벨" + str4;
            sm.AfterAccount.text = "물 주는 양 " + "+" + str3 + "%";
        }
    }

    void ResetSkill()
    {
        Time.timeScale = 1;
        SkillOneSet = false;
        SkillTwoSet = false;
        SkillThreeSet = false;
        SkillFourSet = false;
    }
}
