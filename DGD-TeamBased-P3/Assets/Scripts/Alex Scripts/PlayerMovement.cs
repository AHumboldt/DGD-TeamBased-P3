using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private GameObject Tile;

    private GameObject ForwardDetection;
    private GameObject LeftDetection;
    private GameObject RightDetection;
    
    public bool ForwardPossible;
    public bool LeftPossible;
    public bool RightPossible;

    public bool FacingUp = false;
    public bool FacingDown = false;
    public bool FacingLeft = false;
    public bool FacingRight = false;

    private CheckForward FCheck;
    private CheckLeft LCheck;
    private CheckRight RCheck;
    
    //To do List:
    //
    //- Input in Update, respond in FixedUpdate
    
    void Start()
    {
        
        Tile = GameObject.FindWithTag("Tile");

        FCheck = GameObject.FindWithTag("FTCheck").GetComponent<CheckForward>();
        LCheck = GameObject.FindWithTag("LTCheck").GetComponent<CheckLeft>();
        RCheck = GameObject.FindWithTag("RTCheck").GetComponent<CheckRight>();
        
    }


    void Update()
    {

        if (FCheck.Detect == true) ForwardPossible = true;
        else ForwardPossible = false;
        
        if (LCheck.Detect == true) LeftPossible = true;
        else LeftPossible = false;
        
        if (RCheck.Detect == true) RightPossible = true;
        else RightPossible = false;
        
        if (this.transform.rotation.eulerAngles.z == 0) //up
        {
            FacingUp = true;
            FacingDown = false;
            FacingLeft = false;
            FacingRight = false;
        }
        else if (this.transform.rotation.eulerAngles.z == 180) //Down
        {
            FacingUp = false;
            FacingDown = true;
            FacingLeft = false;
            FacingRight = false;
        }
        else if (this.transform.rotation.eulerAngles.z == 90) //left
        {
            FacingUp = false;
            FacingDown = false;
            FacingLeft = true;
            FacingRight = false;
        }
        else if (this.transform.rotation.eulerAngles.z == -90) //right
        {
            FacingUp = false;
            FacingDown = false;
            FacingLeft = false;
            FacingRight = true;
        }

        if (Input.GetKeyDown(KeyCode.W) && ForwardPossible == true)
        {
            
            if(FacingUp == true)transform.position += new Vector3(0, 1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, -1, 0);
            if(FacingLeft == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(1, 0, 0);
            
        }

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

        /*if (Floor.tag == "TileF")
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
        }*/

    }

    private void OnTriggerExit2D(Collider2D Floor)
    {
        //Legal = false;
    }

}
