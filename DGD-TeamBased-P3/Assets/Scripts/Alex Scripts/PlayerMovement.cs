using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject Tile;
    
    public bool ForwardPossible;
    public bool LeftPossible;
    public bool RightPossible;
    
    void Start()
    {

        Tile = GameObject.FindWithTag("Tile");
        
    }


    void Update()
    {

 

            if (Input.GetKeyDown(KeyCode.W) && ForwardPossible == true) transform.position += new Vector3(0, 1, 0);
            if (Input.GetKeyDown(KeyCode.A) && LeftPossible == true)
            {
                
                transform.position += new Vector3(-1, 0, 0);
                transform.Rotate(0, 0, 90);

            }

            if (Input.GetKeyDown(KeyCode.D) && RightPossible == true)
            {
                
                transform.position += new Vector3(1, 0, 0);
                transform.Rotate(0, 0, -90);
                
            }
        

    }

    void OnTriggerEnter2D(Collider2D Floor)
    {

        if (Floor.tag == "TileF")
        {
            ForwardPossible = true;
            LeftPossible = false;
            RightPossible = false;
        }
        if (Floor.tag == "TileL")
        {
            ForwardPossible = false;
            LeftPossible = true;
            RightPossible = false;
        }

        if (Floor.tag == "TileR")
        {
            ForwardPossible = false;
            LeftPossible = false;
            RightPossible = true;
        }
        
        if (Floor.tag == "TileFL")
        {
            ForwardPossible = true;
            LeftPossible = true;
            RightPossible = false;
        }
        
        if (Floor.tag == "TileFR")
        {
            ForwardPossible = true;
            LeftPossible = false;
            RightPossible = true;
        }
        
        if (Floor.tag == "TileLR")
        {
            ForwardPossible = false;
            LeftPossible = true;
            RightPossible = true;
        }
        
        if (Floor.tag == "TileFLR")
        {
            ForwardPossible = true;
            LeftPossible = true;
            RightPossible = true;
        }
        
    }

    private void OnTriggerExit2D(Collider2D Floor)
    {
        //Legal = false;
    }

}
