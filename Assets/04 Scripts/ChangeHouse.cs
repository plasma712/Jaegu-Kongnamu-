using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ChangeHouse : MonoBehaviour {

    public SpriteRenderer originSprite;
    public Sprite[] sprite;
    public ScriptManger sm;
    public Image BeforeHouse;
    public Image AfterHouse;
    private int HouseIndex;
    public Button HouseButton;
    public TextMeshProUGUI HousePrice;
    private int HouseUpgadePrice;
	// Use this for initialization
	void Start () {
	}

    private void Awake()
    {
        HouseUpgadePrice = 1000;
        HouseIndex = 0;
        BeforeHouse.sprite = sprite[HouseIndex];
        AfterHouse.sprite = sprite[HouseIndex + 1];
        HouseButton.onClick.AddListener(ChangeClick);
    }

    // Update is called once per frame
    void Update () {
        if (HouseUpgadePrice > sm.BeansCount)
            HousePrice.color = new Color(255, 0, 0);
        else
            HousePrice.color = new Color(255, 255, 255);

        string str = string.Format("{0:f0}", HouseUpgadePrice);
        HousePrice.text = str;
    }

    public void ChangeClick() // 두 번째 하우스
    {
        if (sm.BeansCount > 1000)
        {
            HouseUpgadePrice += 4000;

            originSprite.sprite = sprite[1];
            sm.MinusBeans(HouseUpgadePrice);
            sm.textRespawn.RespawnSpeed = 1.5f;

            BeforeHouse.sprite = sprite[1];
            AfterHouse.sprite = sprite[2];

            //HouseIndexControl();
            HouseButton.onClick.RemoveAllListeners();
            HouseButton.onClick.AddListener(ChangeClick2);
        }
    }

    public void ChangeClick2() // 세 번째 하우스
    {

        if (sm.BeansCount > 5000)
        {
            HouseUpgadePrice += 8000;

            originSprite.sprite = sprite[2];
            BeforeHouse.sprite = sprite[2];
            AfterHouse.sprite = sprite[3];
            sm.MinusBeans(HouseUpgadePrice);
            sm.textRespawn.RespawnSpeed = 1.0f;

            //HouseIndexControl();
            HouseButton.onClick.RemoveAllListeners();
            HouseButton.onClick.AddListener(ChangeClick3);
        }
    }

    public void ChangeClick3() //네 번재 하우스
    {

        if (sm.BeansCount > 13000)
        {
            HouseUpgadePrice += 12000;
            originSprite.sprite = sprite[3];
            BeforeHouse.sprite = sprite[3];
            AfterHouse.sprite = sprite[3];
            sm.MinusBeans(HouseUpgadePrice);
            sm.textRespawn.RespawnSpeed = 0.5f;
            //HouseIndexControl();
            HouseButton.onClick.RemoveAllListeners();
            HouseButton.onClick.AddListener(ChangeClick4);
        }
    }

    public void ChangeClick4()
    {
        if (sm.BeansCount > 25000)
        {
            originSprite.sprite = sprite[3];
            sm.MinusBeans(HouseUpgadePrice);
            sm.textRespawn.RespawnSpeed = 0.3f;
            HouseButton.onClick.RemoveAllListeners();
        }
    }

    void HouseIndexControl()
    {
        BeforeHouse.sprite = sprite[HouseIndex];
        AfterHouse.sprite = sprite[HouseIndex + 1];
        HouseIndex += 1;
    }
}
