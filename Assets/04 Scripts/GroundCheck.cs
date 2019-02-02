using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {
    public Jack_anim JackAnim;
    public GameObject[] Tile;
    private GameObject SelectTile;
    public GameObject Jack;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        SoltingTile();
	}

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Ground")
        {
           // JackAnim.Grounded = true;
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Ground")
        {
            
        }
    }

    void SoltingTile()
    {
        for (int i = 0; i < Tile.Length; i++)
        {
            //if(gameObject.CompareTag())
        }
    }

    bool CheckTile(Collider2D col)
    {
        bool corect = false;
        return corect;
    }
}
