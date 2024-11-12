using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckRight : MonoBehaviour
{

    private GameObject Tile;
    public bool Detect;
    
    // Start is called before the first frame update
    void Start()
    {
        
        Tile = GameObject.FindWithTag("Tile");
        
    }


    private void OnTriggerEnter2D(Collider2D Floor)
    {

        if (Floor.tag == "Tile") Detect = true;

    }
    
    private void OnTriggerExit2D(Collider2D Floor)
    {

        Detect = false;

    }
}