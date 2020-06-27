using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Grid_Script : MonoBehaviour {

    public bool[] reserved_tiles;
    public int[] tiles_type;

    public bool[] score_combo;

    public Canvas score_canvas;
    public Text score_text;

    //tiles_type = 1 --> X
    //tiles_type = 2 --> O
    //tiles_type = 0 --> default - not reserved

    // Use this for initialization
    void Start () {
        reserved_tiles = new bool[] { false, false, false, false, false, false, false, false, false };
        tiles_type = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        score_combo = new bool[] { false, false, false, false, false, false, false, false};
    }

    // Update is called once per frame
    void Update () {
	}

    public void check_tiles()
    {
        //HL1
        if (tiles_type[0] == 1 && tiles_type[1] == 1 && tiles_type[2] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        else if (tiles_type[0] == 2 && tiles_type[1] == 2 && tiles_type[2] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

        //HL2
        if (tiles_type[3] == 1 && tiles_type[4] == 1 && tiles_type[5] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        else if (tiles_type[3] == 2 && tiles_type[4] == 2 && tiles_type[5] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

        //HL3
        if (tiles_type[6] == 1 && tiles_type[7] == 1 && tiles_type[8] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        else if (tiles_type[6] == 2 && tiles_type[7] == 2 && tiles_type[8] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

        //VL1
        if (tiles_type[0] == 1 && tiles_type[3] == 1 && tiles_type[6] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        if (tiles_type[0] == 2 && tiles_type[3] == 2 && tiles_type[6] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

        //VL2
        if (tiles_type[1] == 1 && tiles_type[4] == 1 && tiles_type[7] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        else if (tiles_type[1] == 2 && tiles_type[4] == 2 && tiles_type[7] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

        //VL3
        if (tiles_type[2] == 1 && tiles_type[5] == 1 && tiles_type[8] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        else if (tiles_type[2] == 2 && tiles_type[5] == 2 && tiles_type[8] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

        //DL1
        if (tiles_type[0] == 1 & tiles_type[4] == 1 && tiles_type[8] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        else if (tiles_type[0] == 2 && tiles_type[4] == 2 && tiles_type[8] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

        //DL2
        if (tiles_type[2] == 1 && tiles_type[4] == 1 && tiles_type[6] == 1)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(0);
        }
        else if (tiles_type[2] == 2 && tiles_type[4] == 2 && tiles_type[6] == 2)
        {
            score_text.enabled = true;
            this.gameObject.GetComponent<Score>().Update_Score(1);
        }

    }
}
