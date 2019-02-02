using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Geo : MonoBehaviour {

    public GameObject BackGround_;

    public ScriptManger Sm;

    public float Speed;

	// Update is called once per frame
	void Update ()
    {
        BackGround_.transform.Translate(Vector3.down * Time.deltaTime * Sm.HeightSpeed * Speed);

        if(Sm.HeightMount>90000)
        {
            BackGround_.SetActive(false);
        }
    }
}
