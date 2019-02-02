using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundRepeat : MonoBehaviour
{
    // public PositionCount pc;

    public float scrollSpeed = 1;

    public float Bspeed;

    public float offset_y;

    private Material thisMaterial;


    public ScriptManger Sm;
    void Start()
    {
        thisMaterial = GetComponent<Renderer>().material;
    }

    void Update()
    {
        // if (pc.CusPos > 500)
        // {
        //
        //     Bspeed = pc.speed * 0.001f;
        //
        //     scrollSpeed = Bspeed;
        //     Vector2 newOffset = thisMaterial.mainTextureOffset;
        //
        //     newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));
        //
        //     offset_y = newOffset.y;
        //
        //     thisMaterial.mainTextureOffset = newOffset;
        // }


        Vector2 newOffset = thisMaterial.mainTextureOffset;

        newOffset.Set(0, newOffset.y + (scrollSpeed * Time.deltaTime));

        offset_y = newOffset.y;

        thisMaterial.mainTextureOffset = newOffset;

        if (Sm.CurHealth == 0)
        {
            scrollSpeed = 0;
        }

    }
}
