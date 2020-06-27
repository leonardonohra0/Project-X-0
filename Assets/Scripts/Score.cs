using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour {

    public Text score_text;
    public Button again_btn;
    public GameObject spawner;
    public GameObject[] sprite_x;
    public GameObject[] sprite_o;
    public int[] score;

	// Use this for initialization
	void Start () {
        score = new int[]{ 0, 0};
        again_btn.gameObject.SetActive(false);
        again_btn.GetComponent<Button>().onClick.AddListener(() => Restart());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Update_Score(int nb)
    {
        if (nb == 0)
            score_text.text = "Player X has won!";
        else if (nb == 1)
            score_text.text = "Player O has won!";

        again_btn.gameObject.SetActive(true);

        spawner.GetComponent<XO_Spawner>().enabled = false;
        sprite_x = GameObject.FindGameObjectsWithTag("X_Sprite");
        sprite_o = GameObject.FindGameObjectsWithTag("O_Sprite");
         foreach(GameObject sprite in sprite_o)
        {
            Destroy(sprite);
        }
        foreach (GameObject sprite in sprite_x)
        {
            Destroy(sprite);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

}
