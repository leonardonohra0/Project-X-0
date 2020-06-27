using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eraser_Script : MonoBehaviour {

    public int p_xo_id;
    public string xo_tag;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonUp(0))
        {
            Erase_XO(p_xo_id);
        }
	}

    void Erase_XO(int id)
    {

    }
}
