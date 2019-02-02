using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabSetActive : MonoBehaviour {

    public GameObject button;
    public ScriptManger sm;
    public GameManger gm;
    bool set;
    private float ControllTime;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        ControllFillAmount();
	}

    void ControllFillAmount()
    {
        if (set == true)
        {
            sm.ShopTab.fillAmount += Time.deltaTime*10;
            sm.ShopTree.fillAmount += Time.deltaTime*10;
        }
        else
        {
            sm.ShopTab.fillAmount -= Time.deltaTime;
            sm.ShopTree.fillAmount -= Time.deltaTime;
        }
    }

    public void Click()
    {
        gm.PopUpUpgradeButton.onClick.AddListener(sm.ClickSkillOne);
        SetInit();
        set = !set;
        gameObject.SetActive(set);
        
        if(set == true)
        {
            sm.ShopTab.fillAmount = 0;
            sm.ShopTree.fillAmount = 0;
            gm.Basic_Tree.SetActive(false);
        }
        else
        {
            sm.ShopTab.fillAmount = 1;
            sm.ShopTree.fillAmount = 1;
            gm.Basic_Tree.SetActive(true);
        }
    }

    void SetInit()
    {
        gm.CharTab.SetActive(false);
        gm.HouseTab.SetActive(false);
        gm.MenuTab.SetActive(false);
        gm.ShopTab.SetActive(false);
    }
}
