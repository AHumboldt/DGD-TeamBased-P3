using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public List<string> PossibleOptions = new List<string> { "Forward", "Backward", "Left", "Right" };
    public List<string> Available = new List<string>();
    
    void Start()
    {

        FCheck = GameObject.FindWithTag("EFTCheck").GetComponent<EnemyCheckForward>();
        BCheck = GameObject.FindWithTag("EBTCheck").GetComponent<EnemyCheckBackwards>();
        LCheck = GameObject.FindWithTag("ELTCheck").GetComponent<EnemyCheckLeft>();
        RCheck = GameObject.FindWithTag("ERTCheck").GetComponent<EnemyCheckRight>();
        
    }


    void Update()
    {

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


        if (FCheck.Detect == true)
        {
            
            ForwardPossible = true;
            Available.Add(PossibleOptions[0]);
            
        }

        if (FCheck.Detect == false) ForwardPossible = false;
        
        if (BCheck.Detect == true) BackwardPossible = true;
        {
            
            BackwardPossible = true;
            Available.Add(PossibleOptions[1]);
            
        }
        if (BCheck.Detect == false) BackwardPossible = false;
        
        if (LCheck.Detect == true) LeftPossible = true;
        {
            
            LeftPossible = true;
            Available.Add(PossibleOptions[2]);
            
        }
        if (LCheck.Detect == false) LeftPossible = false;
        
        if (RCheck.Detect == true) RightPossible = true;
        {
            
            RightPossible = true;
            Available.Add(PossibleOptions[3]);
            
        }
        if (RCheck.Detect == false) RightPossible = false;
        
        
        for (int i = 0; i < Available.Count; i++)
        {
            
            Debug.Log(Available[i]);

        }
        

        if (Input.GetKeyDown(KeyCode.W) && ForwardPossible == true)
        {

            if(FacingUp == true)transform.position += new Vector3(0, 1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, -1, 0);
            if(FacingLeft == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(1, 0, 0);

        }

        if (Input.GetKeyDown(KeyCode.S) && BackwardPossible == true)
        {
            
            if(FacingUp == true)transform.position += new Vector3(0, -1, 0);
            if(FacingDown == true)transform.position += new Vector3(0, 1, 0);
            if(FacingLeft == true)transform.position += new Vector3(1, 0, 0);
            if(FacingRight == true)transform.position += new Vector3(-1, 0, 0);
            transform.Rotate(0, 0, 180);
            
        }

        if (Input.GetKeyDown(KeyCode.A) && LeftPossible == true)
        {

            if(FacingUp == true)transform.position += new Vector3(-1, 0, 0);
            if(FacingDown == true)transform.position += new Vector3(1, 0, 0);
            if(FacingLeft == true)transform.position += new Vector3(0, -1, 0);
            if(FacingRight == true)transform.position += new Vector3(0, 1, 0);
            //transform.Rotate(0, 0, 90);

        }

            if (Input.GetKeyDown(KeyCode.D) && RightPossible == true)
            {

                if(FacingUp == true)transform.position += new Vector3(1, 0, 0);
                if(FacingDown == true)transform.position += new Vector3(-1, 0, 0);
                if(FacingLeft == true)transform.position += new Vector3(0, 1, 0);
                if(FacingRight == true)transform.position += new Vector3(0, -1, 0);
                transform.Rotate(0, 0, -90);

            }
        

    }
    
}
