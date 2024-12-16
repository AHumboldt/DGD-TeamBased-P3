using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RageCheck : MonoBehaviour
{

    public bool Rage;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            
            Debug.Log("Player Spotted");
            Rage = true;

        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {

        Rage = false;

    }
}
