using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jack_Effect : MonoBehaviour
{
    public GameObject effect;
    public GameObject Point;

	// Use this for initialization
	void Start ()
    {
        Point = GameObject.Find("Point");

	}

	
	// Update is called once per frame
	void Update ()
    {
        effect.transform.position = Point.transform.position;
	}

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Pest")
        {
            Destroy(this.gameObject, 1.0f);
            Debug.Log("총알충돌");
        }

        if (other.transform.tag == "Fly")
        {
            Destroy(this.gameObject, 1.0f);
            Debug.Log("총알충돌");
        }

    }

}
