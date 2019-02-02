using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Slide_Up_Citical : MonoBehaviour
{


    public TextMeshProUGUI Critical;
    public float Alpha;
    public float AlphaSpeed;
    private float deTime;
    public float UpSpeed;
    // Use this for initialization


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
                Critical.color = new Color(255, 0, 0, Alpha);
            }

        }

        if (deTime > 1.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
