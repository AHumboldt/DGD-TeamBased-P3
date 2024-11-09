using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject Tile;
    public bool Legal = false;
    
    // Start is called before the first frame update
    void Start()
    {

        Tile = GameObject.FindWithTag("Tile");
        
    }


    void Update()
    {

        if (Legal == true)
        {

            if (Input.GetKeyDown(KeyCode.W)) transform.position += new Vector3(0, 1, 0);

        }

    }

    void OnTriggerEnter2D(Collider2D Floor)
    {

        if (Floor.tag == "Tile") Debug.Log("Ooh... They touched...");
        Legal = true;

    }

    private void OnTriggerExit2D(Collider2D Floor)
    {
        Legal = false;
    }

}
