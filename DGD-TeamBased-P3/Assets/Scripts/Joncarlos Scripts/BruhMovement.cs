using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruhMovement : MonoBehaviour
{
    private GameObject Tile;
    
    public bool ForwardPossible;
    public bool BackwardPossible;
    public bool LeftPossible;
    public bool RightPossible;

    public bool FacingUp = false;
    public bool FacingDown = false;
    public bool FacingLeft = false;
    public bool FacingRight = false;
    
    public bool MoveUp = false;
    public bool MoveDown = false;
    public bool MoveLeft = false;
    public bool MoveRight = false;

    private CheckForward FCheck;
    private CheckBackwards BCheck;
    private CheckLeft LCheck;
    private CheckRight RCheck;

    public AudioSource MainMusic;
    
    public float timer = 0;
    public float spawnRate = 0.79f;
    
    //To do List:
    //
    //- FIX THIS DAMN BACK KEY
    //- Input in Update, respond in FixedUpdate
    
    void Start()
    {
        
        Tile = GameObject.FindWithTag("Tile");

        FCheck = GameObject.FindWithTag("FTCheck").GetComponent<CheckForward>();
        BCheck = GameObject.FindWithTag("BTCheck").GetComponent<CheckBackwards>();
        LCheck = GameObject.FindWithTag("LTCheck").GetComponent<CheckLeft>();
        RCheck = GameObject.FindWithTag("RTCheck").GetComponent<CheckRight>();
        
        MainMusic.Play();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) && timer >= 0.5f)
        {
            Debug.Log("MovingUp");
            MoveUp = true;
            
        }
        if (Input.GetKeyDown(KeyCode.S) && timer >= 0.5f)
        {
            MoveDown = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && timer >= 0.5f)
        {
            MoveLeft = true;
        }
        if (Input.GetKeyDown(KeyCode.D) && timer >= 0.5f)
        {
            MoveRight = true;
        }
    }
    void FixedUpdate()
    {

        timer += Time.deltaTime;
        if (timer >= spawnRate)
        {
            timer = 0;
        }
        
        if (MoveUp == true && ForwardPossible == true && timer >= 0.75f)
        {
            MoveUp = false;
            if(FacingUp == true)transform.position += new Vector3(0, 1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, -1, 0);
            if(FacingLeft == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(1, 0, 0);

        }

        if (MoveDown == true && BackwardPossible == true && timer >= 0.75f)
        {
            MoveDown = false;
            if(FacingUp == true)transform.position += new Vector3(0, -1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, 1, 0);
            if(FacingLeft == true)transform.position += new Vector3(1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(-1, 0, 0);
            //transform.Rotate(0, 0, 180);
            
        }

        if (MoveLeft == true && LeftPossible == true && timer >= 0.75f)
        {
            MoveLeft = false;
            if(FacingUp == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingDown == true)transform.position += new Vector3(1, 0, 0);
            if(FacingLeft == true)transform.position += new Vector3(0, -1, 0);
            if(FacingRight == true)transform.position += new Vector3(0, 1, 0);
            transform.Rotate(0, 0, 90);

        }

        if (MoveRight == true && RightPossible == true && timer >= 0.75f)
        {
            MoveRight = false;
            if(FacingUp == true)transform.position += new Vector3(1, 0, 0);
            if(FacingDown == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingLeft == true)transform.position += new Vector3(0, 1, 0);
            if(FacingRight == true)transform.position += new Vector3(0, -1, 0);
            transform.Rotate(0, 0, -90);

        }
        if (this.transform.rotation.eulerAngles.z == 0 || this.transform.rotation.eulerAngles.z == 360 || this.transform.rotation.eulerAngles.z == -360) //up
        {
            
            Debug.Log("The Player is now facing up");
            
            FacingUp = true;
            FacingDown = false;
            FacingLeft = false;
            FacingRight = false;
        }
        if (this.transform.rotation.eulerAngles.z == 180 || this.transform.rotation.eulerAngles.z == -180) //Down
        {
                        
            Debug.Log("The Player is now facing Down");
        
            FacingUp = false;
            FacingDown = true;
            FacingLeft = false;
            FacingRight = false;
            
        }
        if (this.transform.rotation.eulerAngles.z == 90 || this.transform.rotation.eulerAngles.z == -270) //left
        {
                        
            Debug.Log("The Player is now facing left");

            FacingUp = false;
            FacingDown = false;
            FacingLeft = true;
            FacingRight = false;
        }
        if (this.transform.rotation.eulerAngles.z == -90 || this.transform.rotation.eulerAngles.z == 270) //right
        {
                        
            Debug.Log("The Player is now facing Right");

            FacingUp = false;
            FacingDown = false;
            FacingLeft = false;
            FacingRight = true;
        }

        
        if (FCheck.Detect == true) ForwardPossible = true;
        if (FCheck.Detect == false) ForwardPossible = false;
        
        if (BCheck.Detect == true) BackwardPossible = true;
        if (BCheck.Detect == false) BackwardPossible = false;
        
        if (LCheck.Detect == true) LeftPossible = true;
        if (LCheck.Detect == false) LeftPossible = false;
        
        if (RCheck.Detect == true) RightPossible = true;
        if (RCheck.Detect == false) RightPossible = false;
        
       
        

    }

    /*void FixedUpdate()
    {

        if (ClickUp == true)
        {
            
            if(FacingUp == true)transform.position += new Vector3(0, 1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, -1, 0);
            if(FacingLeft == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(1, 0, 0);

            ClickUp = false;

        }
        
        if (ClickDown == true)
        {
            
            

            ClickDown = false;

        }
        
        if (ClickLeft == true)
        {
            
            if(FacingUp == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingDown == true)transform.position += new Vector3(1, 0, 0);
            if(FacingLeft == true)transform.position += new Vector3(0, -1, 0);
            if(FacingRight == true)transform.position += new Vector3(0, 1, 0);
            transform.Rotate(0, 0, 90);

            ClickLeft = false;

        }
        
        if (ClickRight == true)
        {
            
            if(FacingUp == true)transform.position += new Vector3(1, 0, 0);
            if(FacingDown == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingLeft == true)transform.position += new Vector3(0, 1, 0);
            if(FacingRight == true)transform.position += new Vector3(0, -1, 0);
            transform.Rotate(0, 0, -90);

            ClickRight = false;

        }
        

    }*/

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
