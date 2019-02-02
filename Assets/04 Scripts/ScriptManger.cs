using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScriptManger : MonoBehaviour
{
    private GameObject EffectObject;
    public GameObject PositiveEffect;
    public GameObject NegativeEffect;
    public LightEffectControl LightEffectCt;
    public PopUp popUp;
    public PopUpUpgrade popUpupgrade;
    //텍스트 변수
    public TextMeshProUGUI BeansText;
    public TextMeshProUGUI HouseText;
    public TextMeshProUGUI WaterText;
    public TextMeshProUGUI BefroeText;
    public TextMeshProUGUI AfterText;
    public TextMeshProUGUI BeanPrice;
    public TextMeshProUGUI BefroeAccount;
    public TextMeshProUGUI AfterAccount;
    public TextMeshProUGUI Height;
    public TextRespawn textRespawn;
    public TextMeshProUGUI SkillHealthPotion;
    public TextMeshProUGUI SkillHealthUp;
    public TextMeshProUGUI ItemProtect;
    public TextMeshProUGUI ItemGoldEgg;
    public TextMeshProUGUI Height2;


    //탭 이미지 변수
    public Image ShopTab;
    public Image ShopTree;
    public Image CharTab;
    public Image CharTree;
    public Image MenuTab;
    public Image MenuTree;
    public Image HouseTab;
    public Image HouseTree;
    public GetBeans getBeans;

    //내부 데이터 변수
    public float HeightSpeed;
    public float HeightMount;

    public float EnemySpot_HeightMount;


    public float BeansCount; //얻는 총 콩의 수
    public int haveBeans; //일정 주기 마다 얻을 콩의 수 
    public float WaterState; //현재 수분 량
    public float WaterSpeedDown; //수분량이 떨어지는 정도
    public float WaterSpeedUp; //수분량이 떨어지는 정도
    public int PestKill;
    public int MaxHealth; //맥스 체력
    public float CurHealth; // 현재 체력
    public float SkillOnePrice; // 캐릭터 스킬
    public int SkillOneLevel;
    public float SkillThreePrice;
    public int SkillThreeLevel = 0;
    public float SkillTwoPrice;
    public int SkillTwoLevel;
    public float SkillFourPrice;
    public float SkillFourLevel;
    private float alpha = 1;
    private Vector3 firstpostion;
    private float Enemy_RespawnTime;
    private int SkillHealthUpPrice;
    private int SkillHealthPotionPrice;
    public float SkillProtectPrice;
    private int ItemGoldEggPrice;
    private float waterStack;
    public GameObject HouseUpGradeEffect;
    public GameObject House;
    public GameObject HouseHealEffect;
    public bool ButtonActive;
    private Jack_anim JackAnim;

    // Use this for initialization
    void Start()
    {
        BeansCount = 0;
        Enemy_RespawnTime = 0;

        WaterState = 100.0f;
        WaterSpeedDown = 0.5f;

        MaxHealth = 1000;
        CurHealth = MaxHealth;

        SkillOnePrice = 100;
        SkillTwoPrice = 500;
        SkillThreePrice = 300;
        SkillFourPrice = 1000;

        SkillHealthUpPrice = 500;
        SkillProtectPrice = 200;
        SkillHealthPotionPrice = 300;
        ItemGoldEggPrice = 500;
    }

    // Update is called once per frame
    void Update()
    {
        JackAnim = GameObject.FindGameObjectWithTag("Player").GetComponent<Jack_anim>();
        SetText();
        Eenmy_UpDate();
        TextUpdate();
    }

    void TextUpdate()
    {
        if(BeansCount < SkillThreePrice)
        {
            SkillHealthPotion.color = new Color(255, 0, 0);
        }
        else
            SkillHealthPotion.color = new Color(255, 255, 255);

        if (BeansCount < SkillProtectPrice)
        {
            ItemProtect.color = new Color(255, 0, 0);
        }
        else
            ItemProtect.color = new Color(255, 255, 255);

        if (BeansCount < SkillTwoPrice)
        {
            SkillHealthUp.color = new Color(255, 0, 0);
        }
        else
            SkillHealthUp.color = new Color(255, 255, 255);

        if (BeansCount < ItemGoldEggPrice)
        {
            ItemGoldEgg.color = new Color(255, 0, 0);
        }
        else
            ItemGoldEgg.color = new Color(255, 255, 255);
    }

    void Eenmy_UpDate()
    {
        if (HeightMount < 100000)
            Enemy_RespawnTime = 15.0f - HeightMount / (100000 / 14.0f);
    }

    void SetText()
    {

        UpdateBeans();
        UpdateHealhPotion();
        UpdateHealthUp();
        UpdateHeight();
        UpdateHouseHp();
        UpdateProtectText();
    }

    void UpdateProtectText()
    {
        string str = string.Format("{0:f0}", SkillProtectPrice);

        ItemProtect.text = str;
    }

    void UpdateBeans() //콩 텍스트
    {
        string str = string.Format("{0:f0}", BeansCount);

        BeansText.text = str;
    }

    void UpdateHealhPotion() //체력 회복 포션
    {

        string str = string.Format("{0:f0}", SkillThreePrice);
        SkillHealthPotion.text = str;
        
    }


    void UpdateHealthUp() //체력 스킬 업
    {
        string str = string.Format("{0:f0}", SkillTwoPrice);
        SkillHealthUp.text = str;
    }

    void UpdateHouseHp() // 체력 텍스트
    {
        if (CurHealth < 0)
            return;

        string str = string.Format("{0:f0}", CurHealth);

        HouseText.text = str + "/" + MaxHealth;
    }

    void UpdateHeight()//높이 텍스트
    {
        if (CurHealth <= 0)
            return;

        HeightMount += Time.deltaTime * 1.0f;

        EnemySpot_HeightMount += Time.deltaTime * 1.0f;

        string str2 = string.Format("{0:f2}", HeightMount);
        Height2.text = str2 + "M";
    }

    //---------------------------------------------------------------아이템 클릭

    public void ClickNut() // 영양제 아이템 
    {
        if (BeansCount < 300 || CurHealth == MaxHealth)
            return;

        if ((CurHealth + MaxHealth / 2) > MaxHealth)
        {
            CurHealth = MaxHealth;
            EffectObject = Instantiate(PositiveEffect);
            EffectObject.transform.SetParent(HouseText.transform, false);
        }
        else
            PlusHealth(MaxHealth / 2);


        MinusBeans(300);
    }

    public void ClickProtect() // 해충제 아이템
    {
        if (BeansCount < 300)
            return;

        MinusBeans(300);
    }

    public void ClickWaether() // 날씨 아이템
    {
        if (BeansCount < 500)
            return;

        MinusBeans(500);
    }

    public void ClickEgg()
    {

        if (BeansCount < 500)
            return;

        BeansCount -= BeansCount / 5;
    }



    //-----------------------------------------------------------------------스킬
    public void ClickSkillOne() //캐릭터 스킬 버튼
    {
        ButtonActive = true;
        if (BeansCount > SkillOnePrice)
        {
            MinusBeans(SkillOnePrice);
            //haveBeans += 1;
            SkillOnePrice += 100;
            SkillOneLevel += 1;
        }
    }

    public void ClickSkillTwo()// 캐릭터 스킬2 버튼
    {
        ButtonActive = true;
        if (BeansCount > SkillTwoPrice)
        {
            Instantiate(HouseUpGradeEffect, House.transform.position, Quaternion.identity);
            MinusBeans(SkillTwoPrice);
            SkillTwoPrice += (int)(SkillTwoPrice /2);
            MaxHealth += 1000;
            CurHealth = MaxHealth;
            JackAnim.TargetTranform.position = JackAnim.transform.position;

            if (SkillTwoLevel < 3)
            {
                SkillTwoLevel += 1;
            }
        }
    }

    public void ClickSkillThree()// 캐릭터 스킬3 버튼
    {
        ButtonActive = true;
        if (BeansCount > SkillThreePrice)
        {
            if (CurHealth == MaxHealth)
                return;

            Instantiate(HouseHealEffect, House.transform.position, Quaternion.identity);
            MinusBeans(SkillThreePrice);
            JackAnim.TargetTranform.position = JackAnim.transform.position;

            if (MaxHealth - CurHealth < 50)
                CurHealth = MaxHealth;
            else
                CurHealth += 50;

           
        }
    }

    public void ClickSkillFour()// 캐릭터 스킬4 버튼
    {
        if (BeansCount > SkillFourPrice)
        {
            PlusBeans(SkillFourPrice);
            SkillFourPrice += (int)(SkillFourPrice / 8);
            WaterSpeedUp += 0.1f;
            SkillFourLevel += 1;
        }
    }
    //-------------------------------------인수 받는 함수

    public float GetPest_RespawnTime()
    {
        return Enemy_RespawnTime;
    }

    public void PlusBeans(float num)
    {
        BeansCount += num;
        EffectObject = Instantiate(PositiveEffect);
        EffectObject.transform.SetParent(BeansText.transform, false);

    }

    public void MinusBeans(float num)
    {
        BeansCount -= num;
        EffectObject = Instantiate(NegativeEffect);
        EffectObject.transform.SetParent(BeansText.transform, false);
    }

    public void PlusHealth(float num)
    {
        CurHealth += num;
        EffectObject = Instantiate(PositiveEffect);
        EffectObject.transform.SetParent(HouseText.transform, false);
    }

    public void MinusHealth(float num)
    {
        CurHealth -= num;
        EffectObject = Instantiate(NegativeEffect);
        EffectObject.transform.SetParent(HouseText.transform, false);
    }

    public bool IsActive()
    {
        if (ButtonActive == true)
            return true;

        return false;
    }
}
