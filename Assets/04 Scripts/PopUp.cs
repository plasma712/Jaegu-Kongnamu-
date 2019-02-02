using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUp : MonoBehaviour {
    public ScriptManger sm;
    public GameManger gm;
    public Image PopUpImage;
    public Sprite[] ChangeImage;
    public Sprite[] ChangeImageHouse;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void PopupCancel()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
    //---------------------------------------------------------스킬 버튼 함수
    public void ClickPopUpSkillOne()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImage[0];
    }

    public void ClickPopUpSkillTwo()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImage[1];
    }

    public void ClickPopUpSkillThree()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImage[2];
    }

    public void ClickPopUpSkillFour()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImage[3];
    }
    //--------------------------------------------------------하우스 버튼

    public void ClickHouse1()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImageHouse[0];
    }

    public void ClickHouse2()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImageHouse[1];
    }

    public void ClickHouse3()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImageHouse[2];
    }

    public void ClickHouse4()
    {
        Time.timeScale = 0;
        gameObject.SetActive(true);
        PopUpImage.sprite = ChangeImageHouse[3];
    }

}
