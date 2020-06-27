using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XO_Spawner : MonoBehaviour {

    public GameObject sprite;

    public Transform left_spawner;
    public Transform right_spawner;

    public Sprite[] sprite_images;

    public int rand;

    public bool can_spawn;
    public bool can_count;

    void Awake()
    {
        can_spawn = true;
        can_count = true;
        sprite_images = Resources.LoadAll<Sprite>("Sprites/XO");
    }

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (can_spawn && can_count)
        {
            SpawnSprite();
        }
        
	}

    void SpawnSprite()
    {
        rand = Random.Range(0, 2);
        can_spawn = false;
        switch (rand)
        {
            case 0: sprite.GetComponent<SpriteRenderer>().sprite = sprite_images[0];
                sprite.tag = "O_Sprite"; break;
            case 1: sprite.GetComponent<SpriteRenderer>().sprite = sprite_images[1];
                sprite.tag = "X_Sprite"; break;
        }
        Instantiate(sprite, left_spawner.position, left_spawner.rotation);

        Invoke("Reset", 0.4f);
    }

    void Reset()
    {
        can_spawn = true;
    }

}
