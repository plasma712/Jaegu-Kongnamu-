using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Move : MonoBehaviour
{
    public ScriptManger Sm;  

    public GameObject BackGround_1;
    public GameObject BackGround_2;
    public GameObject BackGround_3;

    public float Height;

    public float limit_Height;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

        Height = BackGround_2.gameObject.transform.position.y;
        if (Sm.HeightMount > limit_Height && Height>-136.2)
        {
            BackGround_1.SetActive(true);
            BackGround_2.SetActive(true);

            BackGround_1.transform.Translate(Vector3.down * Time.deltaTime * Sm.HeightSpeed*0.002f);

            BackGround_2.transform.Translate(Vector3.down * Time.deltaTime * Sm.HeightSpeed*0.002f);
        }

        if(Height< -136.2)
        {
            BackGround_1.SetActive(false);
            BackGround_2.SetActive(false);
            BackGround_3.SetActive(true);

        }
    }


}
