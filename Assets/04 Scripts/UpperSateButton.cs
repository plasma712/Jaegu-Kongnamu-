using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpperSateButton : MonoBehaviour {
    bool beansset = false;
    public GameObject Beans;
    // Use this for initialization

    private void Init()
    {
        Beans.SetActive(false);
    }

    public void SetWaterAtc()
    {
        Init();
        if (beansset == true)
            beansset = false;

        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void SetBeansAtc()
    {
        Init();

        beansset = !beansset;
        Beans.SetActive(beansset);

        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void SetHelahAtc()
    {
        Init();
        if(beansset == true)
            beansset = false;

        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    void Flib()
    {
        beansset = !beansset;
    }

    public void Cancel()
    {
        Time.timeScale = 1;
        Beans.SetActive(false);
    }
}
