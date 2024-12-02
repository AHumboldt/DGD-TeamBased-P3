using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyMovement : MonoBehaviour
{
    
    public bool ForwardPossible;
    public bool BackwardPossible;
    public bool LeftPossible;
    public bool RightPossible;

    public bool FacingUp = false;
    public bool FacingDown = false;
    public bool FacingLeft = false;
    public bool FacingRight = false;

    private EnemyCheckForward FCheck;
    private EnemyCheckBackwards BCheck;
    private EnemyCheckLeft LCheck;
    private EnemyCheckRight RCheck;
    
    public List<string> Available = new List<string>();

    public bool ReCalc = true; 
    public int Decider = 999;
    public string Decision;
    public float Timer = 1.5f;
    
    void Start()
    {

        FCheck = GameObject.FindWithTag("EFTCheck").GetComponent<EnemyCheckForward>();
        BCheck = GameObject.FindWithTag("EBTCheck").GetComponent<EnemyCheckBackwards>();
        LCheck = GameObject.FindWithTag("ELTCheck").GetComponent<EnemyCheckLeft>();
        RCheck = GameObject.FindWithTag("ERTCheck").GetComponent<EnemyCheckRight>();
        
    }


    void Update()
    {

        Timer -= Time.deltaTime;
        
        if (this.transform.rotation.eulerAngles.z == 0 || this.transform.rotation.eulerAngles.z == 360 || this.transform.rotation.eulerAngles.z == -360) //up
        {
            
            FacingUp = true;
            FacingDown = false;
            FacingLeft = false;
            FacingRight = false;
            
        }
        if (this.transform.rotation.eulerAngles.z == 180 || this.transform.rotation.eulerAngles.z == -180) //Down
        {
        
            FacingUp = false;
            FacingDown = true;
            FacingLeft = false;
            FacingRight = false;
            
        }
        if (this.transform.rotation.eulerAngles.z == 90 || this.transform.rotation.eulerAngles.z == -270) //left
        {

            FacingUp = false;
            FacingDown = false;
            FacingLeft = true;
            FacingRight = false;
            
        }
        if (this.transform.rotation.eulerAngles.z == -90 || this.transform.rotation.eulerAngles.z == 270) //right
        {

            FacingUp = false;
            FacingDown = false;
            FacingLeft = false;
            FacingRight = true;
            
        }



        if (ReCalc == true)
        {
            
            Available.Clear();
            
            if (FCheck.Detect == true)
            {
            
                ForwardPossible = true;
                Available.Add("Forward");
            
            }

            if (FCheck.Detect == false) ForwardPossible = false;
        
            if (BCheck.Detect == true)
            {
            
                BackwardPossible = true;
                Available.Add("Backward");
            
            }
            if (BCheck.Detect == false) BackwardPossible = false;
        
            if (LCheck.Detect == true)
            {
            
                LeftPossible = true;
                Available.Add("Left");
            
            }
            if (LCheck.Detect == false)
        
                if (RCheck.Detect == true)
                {
            
                    RightPossible = true;
                    Available.Add("Right");
            
                }
            if (RCheck.Detect == false) RightPossible = false;
            
            for (int i = 0; i < Available.Count; i++) Debug.Log(Available[i]);
            
            Decider = Random.Range(0, Available.Count);
            Decision = Available[Decider];
            Debug.Log(Decider);
            
            ReCalc = false;
            
        }





        if (Decision == "Forward")
        {

            if(FacingUp == true)transform.position += new Vector3(0, 1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, -1, 0);
            if(FacingLeft == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(1, 0, 0);

            Decision = "";

        }

        if (Decision == "Backward")
        {
            
            if(FacingUp == true)transform.position += new Vector3(0, -1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, 1, 0);
            if(FacingLeft == true)transform.position += new Vector3(1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(-1, 0, 0);
            //transform.Rotate(0, 0, 180);
            
            Decision = "";
            
        }

        if (Decision == "Left")
        {

            if(FacingUp == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingDown == true)transform.position += new Vector3(1, 0, 0);
            if(FacingLeft == true)transform.position += new Vector3(0, -1, 0);
            if(FacingRight == true)transform.position += new Vector3(0, 1, 0);
            transform.Rotate(0, 0, 90);
            
            Decision = "";

        }

        if (Decision == "Right") 
        {

            if(FacingUp == true)transform.position += new Vector3(1, 0, 0);
            if(FacingDown == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingLeft == true)transform.position += new Vector3(0, 1, 0);
            if(FacingRight == true)transform.position += new Vector3(0, -1, 0);
            transform.Rotate(0, 0, -90);
            
            Decision = "";

        }
        
        if (Timer <= 0)
        {
            
            Timer = 1.5f;
            ReCalc = true;
            
        }
        
    }
    
    void FixedUpdate()
    {
        
        

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            
            Debug.Log("Player Spotted");
            
        }
    }
}
