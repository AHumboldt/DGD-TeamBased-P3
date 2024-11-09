using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject Tile;
    
    // Start is called before the first frame update
    void Start()
    {

        Tile = GameObject.FindWithTag("Tile");
    }

    void OnTriggerEnter2D(Collider2D Floor)
    {

        if (Floor.tag == "Tile") Debug.Log("Ooh... They touched...");

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
