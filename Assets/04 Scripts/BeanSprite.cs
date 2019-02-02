﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeanSprite : MonoBehaviour {
    public SpriteRenderer BeanImage;
    private float alpha;
    public float alphaSpeed;
    // Use this for initialization
    void Start()
    {
        alpha = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (alpha > 0)
            alpha -= Time.deltaTime * alphaSpeed;

        BeanImage.color = new Color(255, 255, 255, alpha);
    }
}