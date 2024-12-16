using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverCheck : MonoBehaviour
{

    public bool End;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "GameOver")
        {
            
            Debug.Log("Player Spotted");
            End = true;

        }
    }
}
