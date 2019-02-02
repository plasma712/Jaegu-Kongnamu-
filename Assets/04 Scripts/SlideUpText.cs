using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEngine.UI;


public class SlideUpText : MonoBehaviour
{

    public TextMeshProUGUI BeanText;
    public Image image;
    public float Alpha;
    public float AlphaSpeed;
    private float deTime;
    public float UpSpeed;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }


    private void Move()
    {
        deTime += Time.deltaTime;

        if (Time.timeScale == 1)
        {
            if (deTime < 0.7f)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + UpSpeed, transform.position.z);
            }

            if (Alpha > 0)
            {
                Alpha -= Time.deltaTime * AlphaSpeed;
                image.color = new Color(255, 255, 255, Alpha);
                BeanText.color = new Color(255, 255, 255, Alpha);
            }

        }

        if (deTime > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
