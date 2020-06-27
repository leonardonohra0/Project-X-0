using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Sprite_Script : MonoBehaviour
{

    public GameObject spawner;
    public GameObject grid;

    private Vector3 screenPoint;
    private Vector3 offset;

    public Vector3[] tiles;

    public Transform current_pos;

    public bool is_clicked;
    public bool is_entered;
    public bool is_placed;
    public bool is_reserved;
    public bool is_x;

    public float speed;

    void Awake()
    {
        speed = 5.0f;
    }

    // Use this for initialization
    void Start()
    {
        spawner = GameObject.FindGameObjectWithTag("XOSpawner");
        grid = GameObject.FindGameObjectWithTag("Grid");

        transform.position = new Vector3(spawner.transform.position.x, spawner.transform.position.y,
            spawner.transform.position.z);

        tiles = new[] {new Vector3(-7.5f, 2.5f, 0),
                       new Vector3(-5, 2.5f, 0),
                       new Vector3(-2.5f, 2.5f, 0),
                       new Vector3(-7.5f, 0, 0),
                       new Vector3(-5, 0, 0),
                       new Vector3(-2.5f, 0, 0),
                       new Vector3(-7.5f, -2.5f, 0),
                       new Vector3(-5, -2.5f, 0),
                       new Vector3(-2.5f, -2.5f, 0)
                        };

        is_clicked = false;
        is_placed = false;
        is_entered = false;

        if (this.gameObject.tag == "X_Sprite")
            is_x = true;
        else
            is_x = false;
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.Translate(Vector3.right * speed * Time.deltaTime);
        if(is_placed == false)
        {
            Invoke("OnDestroy", 7.5f);
        }
        else
        {
            CancelInvoke();
        }

        if(this.gameObject.transform.position == new Vector3(-7.5f, 2.5f, 0))
        {
            is_placed = true;
            is_entered = true;
        }

        if(transform.position.x <= -6.25f && transform.position.x > -8.75f && 
            transform.position.y < 3.75f && transform.position.y > 1.25f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(0);
            }
        }

        else if (transform.position.x < -3.75f && transform.position.x > -6.25f &&
            transform.position.y < 3.75f && transform.position.y > 1.25f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(1);
            }
        }

        else if (transform.position.x < -1.25f && transform.position.x > -3.75f &&
            transform.position.y < 3.75f && transform.position.y > 1.25f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(2);
            }
        }

        if (transform.position.x <= -6.25f && transform.position.x > -8.75f &&
            transform.position.y <= 1.25f && transform.position.y > -1.25f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(3);
            }
        }

        else if (transform.position.x < -3.75f && transform.position.x > -6.25f &&
            transform.position.y <= 1.25f && transform.position.y > -1.25f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(4);
            }
        }

        else if (transform.position.x < -1.25f && transform.position.x > -3.75f &&
            transform.position.y <= 1.25f && transform.position.y > -1.25f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(5);
            }
        }

        if (transform.position.x <= -6.25f && transform.position.x > -8.75f &&
            transform.position.y <= -1.25f && transform.position.y > -3.75f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(6);
            }
        }

        else if (transform.position.x < -3.75f && transform.position.x > -6.25f &&
            transform.position.y <= -1.25f && transform.position.y > -3.75f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(7);
            }
        }

        else if (transform.position.x < -1.25f && transform.position.x > -3.75f &&
            transform.position.y <= -1.25f && transform.position.y > -3.75f)
        {
            is_entered = true;
            if (Input.GetMouseButtonUp(0))
            {
                SnapToTile(8);
            }
        }

        if (Input.GetMouseButtonUp(0) && is_entered == false && is_clicked)
        {
            Destroy(gameObject, 0.25f);
        }

        if (Input.GetMouseButtonUp(0))
        {
            if((this.gameObject.tag == "X_Sprite" || this.gameObject.tag == "O_Sprite") && 
                this.gameObject.transform.position.y != -4.5f)
                Destroy(this.gameObject, 0.25f);
        }

        current_pos = this.gameObject.transform;

    }

    private void OnDestroy()
    {
        Destroy(this.gameObject);
    }

    void OnMouseDown()
    {
        offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
        is_clicked = true;
    }

    private void OnMouseDrag()
    {
        speed = 0.0f;
        Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
        Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
        this.gameObject.transform.position = curPosition;
        
    }

    public void SnapToTile(int nb)
    {
        is_reserved = grid.gameObject.GetComponent<Grid_Script>().reserved_tiles[nb];
        if(is_reserved == false)
        {
            is_placed = true;
            is_reserved = true;
            grid.gameObject.GetComponent<Grid_Script>().reserved_tiles[nb] = true;
            transform.position = tiles[nb];

            gameObject.tag = gameObject.tag + "_Reserved";
            if (this.gameObject.tag == "X_Sprite_Reserved")
                grid.gameObject.GetComponent<Grid_Script>().tiles_type[nb] = 1;
            else if (this.gameObject.tag == "O_Sprite_Reserved")
                grid.gameObject.GetComponent<Grid_Script>().tiles_type[nb] = 2;
            grid.GetComponent<Grid_Script>().check_tiles();
        } 
        
    }

    
}
