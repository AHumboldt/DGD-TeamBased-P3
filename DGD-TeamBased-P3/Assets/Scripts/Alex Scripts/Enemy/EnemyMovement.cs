using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
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
    public string RageDecision;
    public float Timer = 1.5f;
    public float RageTimer = 0;

    public int TestDetect = 0;
    public RageCheck Check;
    public GameOverCheck GameOver;
    public bool RageOn = false;
    public bool CheckArea = true;

    public GameObject Player;
    public Vector3 PlayerPosition;
    public GameObject Enemy;
    public Vector3 EnemyPosition;

    public bool GoUp = false;
    public bool GoDown = false;
    public bool GoLeft = false;
    public bool GoRight = false;
    public string CurrentDirect;


    void Start()
    {

        FCheck = GameObject.FindWithTag("EFTCheck").GetComponent<EnemyCheckForward>();
        BCheck = GameObject.FindWithTag("EBTCheck").GetComponent<EnemyCheckBackwards>();
        LCheck = GameObject.FindWithTag("ELTCheck").GetComponent<EnemyCheckLeft>();
        RCheck = GameObject.FindWithTag("ERTCheck").GetComponent<EnemyCheckRight>();

        PlayerPosition = GameObject.FindWithTag("Player").transform.position;
        EnemyPosition = GameObject.FindWithTag("Enemy").transform.position;

    }

    private void OnTriggerEnter2D(Collider2D Player)
    {
        if (Player.tag == "Player")
        {
            SceneManager.LoadScene("YouLose");
        }
    }

    void Update()
    {

        Debug.Log(PlayerPosition);
        
        Timer -= Time.deltaTime;
        RageTimer -= Time.deltaTime;
        
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
// Enemy enter player game over
        if (ReCalc == true)
        {
            
            Available.Clear();
            
            if (FCheck.Detect == true) ForwardPossible = true;
            if (FCheck.Detect == false) ForwardPossible = false;
        
            if (BCheck.Detect == true) BackwardPossible = true;
            if (BCheck.Detect == false) BackwardPossible = false;
        
            if (LCheck.Detect == true) LeftPossible = true;
            if (LCheck.Detect == false) LeftPossible = false;
        
            if (RCheck.Detect == true) RightPossible = true;
            if (RCheck.Detect == false) RightPossible = false;
            
            if (RageOn == false)
            {
                
                
            if (ForwardPossible == true && BackwardPossible == false && LeftPossible == false && RightPossible == false)
            {
                
                for (int i = 0; i <= 10; i++) Available.Add("Forward");
                
            }
            if (ForwardPossible == false && BackwardPossible == true && LeftPossible == false && RightPossible == false)
            {
                
                for (int i = 0; i <= 10; i++) Available.Add("Backward");
                
            }
            if (ForwardPossible == false && BackwardPossible == false && LeftPossible == true && RightPossible == false)
            {
                
                for (int i = 0; i <= 10; i++) Available.Add("Left");
                
            }
            if (ForwardPossible == false && BackwardPossible == false && LeftPossible == false && RightPossible == true)
            {
                
                for (int i = 0; i <= 10; i++) Available.Add("Right");
                
            }
            if (ForwardPossible == true && BackwardPossible == true && LeftPossible == false && RightPossible == false)
            {

                Available.Add("Backward");
                for (int i = 0; i <= 9; i++) Available.Add("Forward");
                
            }
            if (ForwardPossible == true && BackwardPossible == false && LeftPossible == true && RightPossible == false)
            {

                for (int i = 0; i <= 5; i++) Available.Add("Forward");
                for (int i = 0; i <= 5; i++) Available.Add("Left");
                
            }
            if (ForwardPossible == true && BackwardPossible == false && LeftPossible == false && RightPossible == true)
            {

                for (int i = 0; i <= 5; i++) Available.Add("Forward");
                for (int i = 0; i <= 5; i++) Available.Add("Right");
                
            }
            if (ForwardPossible == false && BackwardPossible == true && LeftPossible == true && RightPossible == false)
            {
                
                Available.Add("Backward");
                for (int i = 0; i <= 9; i++) Available.Add("Left");
                
            }
            if (ForwardPossible == false && BackwardPossible == true && LeftPossible == false && RightPossible == true)
            {
                
                Available.Add("Backward");
                for (int i = 0; i <= 9; i++) Available.Add("Right");
                
            }
            if (ForwardPossible == true && BackwardPossible == true && LeftPossible == true && RightPossible == false)
            {
                
                for (int i = 0; i <= 2; i++) Available.Add("Backward");
                for (int i = 0; i <= 4; i++) Available.Add("Forward");
                for (int i = 0; i <= 4; i++) Available.Add("Left");
                
            }
            if (ForwardPossible == true && BackwardPossible == true && LeftPossible == false && RightPossible == true)
            {
                
                for (int i = 0; i <= 2; i++) Available.Add("Backward");
                for (int i = 0; i <= 4; i++) Available.Add("Forward");
                for (int i = 0; i <= 4; i++) Available.Add("Right");
                
            }
            if (ForwardPossible == true && BackwardPossible == false && LeftPossible == true && RightPossible == true)
            {

                for (int i = 0; i <= 6; i++) Available.Add("Forward");
                for (int i = 0; i <= 2; i++) Available.Add("Left");
                for (int i = 0; i <= 2; i++) Available.Add("Right");
                
            }
            if (ForwardPossible == false && BackwardPossible == true && LeftPossible == true && RightPossible == true)
            {
                
                    for (int i = 0; i <= 2; i++) Available.Add("Backward");
                    for (int i = 0; i <= 4; i++) Available.Add("Left");
                   for (int i = 0; i <= 4; i++) Available.Add("Right");
                
            }
            if (ForwardPossible == true && BackwardPossible == true && LeftPossible == true && RightPossible == true)
                {
                
                    Available.Add("Backward");
                    for (int i = 0; i <= 3; i++) Available.Add("Forward");
                    for (int i = 0; i <= 3; i++) Available.Add("Left");
                    for (int i = 0; i <= 3; i++) Available.Add("Right");
                
                }
            
                Decider = Random.Range(0, Available.Count);
                Decision = Available[Decider];
                Debug.Log(Decider);
            
            }

            if (RageOn == true)
            {

                if (EnemyPosition.x == PlayerPosition.x && GoLeft == true || EnemyPosition.x == PlayerPosition.x && GoRight == true || EnemyPosition.y == PlayerPosition.y && GoUp == true || EnemyPosition.y == PlayerPosition.y && GoDown == true || RageTimer <= 0)
                {
                    
                    Debug.Log("We've reset");

                    GoDown = false;
                    GoUp = false;
                    GoRight = false;
                    GoLeft = false;
                
                    RageOn = false;
                    CheckArea = true;
                
                }

                if (EnemyPosition.x == PlayerPosition.x)
                {

                    GoLeft = false;
                    GoRight = false;

                }
                
                if (EnemyPosition.y == PlayerPosition.y)
                {

                    GoUp = false;
                    GoDown = false;

                }

                if (GoLeft == true) CurrentDirect = "Left";
                if (GoRight == true) CurrentDirect = "Right";
                if (GoUp == true) CurrentDirect = "Up";
                if (GoDown == true) CurrentDirect = "Down";

                

                if (CurrentDirect == "Up")
                {

                    if (FacingUp == true)
                    {

                        if (ForwardPossible == true) Decision = "Forward";
                        else if (ForwardPossible == false)
                        {

                            if (LeftPossible == true) Decision = "Left";
                            if (RightPossible == true) Decision = "Right";

                        }

                    }

                    if (FacingDown == true)
                    {
                        
                        if (BackwardPossible == true) Decision = "Backward";
                        else if (BackwardPossible == false)
                        {

                            if (LeftPossible == true) Decision = "Right";
                            if (RightPossible == true) Decision = "Left";

                        }

                    }
                    
                    if (FacingLeft == true)
                    {
                        
                        if (RightPossible == true) Decision = "Right";
                        else if (RightPossible == false)
                        {

                            if (BackwardPossible == true) Decision = "Backward";
                            if (ForwardPossible == true) Decision = "Forward";

                        }

                    }
                    
                    if (FacingRight == true)
                    {
                        
                        if (LeftPossible == true) Decision = "Left";
                        else if (LeftPossible == false)
                            {

                                if (BackwardPossible == true) Decision = "Backward";
                                if (ForwardPossible == true) Decision = "Forward";
                            
                            }

                        }
                        
                    }

                if (CurrentDirect == "Down")
                {
                    
                        if (FacingUp == true)
                        {

                            if (BackwardPossible == true) Decision = "Backward";
                            else if (BackwardPossible == false)
                            {

                                if (LeftPossible == true) Decision = "Left";
                                if (RightPossible == true) Decision = "Right";

                            }

                        }

                        if (FacingDown == true)
                        {
                        
                            if (ForwardPossible == true) Decision = "Forward";
                            else if (ForwardPossible == false)
                            {

                                if (LeftPossible == true) Decision = "Left";
                                if (RightPossible == true) Decision = "Right";

                            }

                        }
                    
                        if (FacingLeft == true)
                        {
                        
                            if (LeftPossible == true) Decision = "Left";
                            else if (LeftPossible == false)
                            {

                                if (BackwardPossible == true) Decision = "Backward";
                                if (ForwardPossible == true) Decision = "Forward";

                            }

                        }
                    
                        if (FacingRight == true)
                        {
                        
                            if (RightPossible == true) Decision = "Right";
                            else if (RightPossible == false)
                            {

                                if (BackwardPossible == true) Decision = "Backward";
                                if (ForwardPossible == true) Decision = "Forward";
                            
                            }

                        }
                    
                }
                
                if (CurrentDirect == "Left")
                {
                    
                        if (FacingUp == true)
                        {

                            if (LeftPossible == true) Decision = "Left";
                            else if (LeftPossible == false)
                            {

                                if (ForwardPossible == true) Decision = "Forward";
                                if (BackwardPossible == true) Decision = "Backward";

                            }

                        }

                        if (FacingDown == true)
                        {
                        
                            if (RightPossible == true) Decision = "Right";
                            else if (RightPossible == false)
                            {

                                if (BackwardPossible == true) Decision = "Backward";
                                if (ForwardPossible == true) Decision = "Forward";

                            }

                        }
                    
                        if (FacingLeft == true)
                        {
                        
                            if (ForwardPossible == true) Decision = "Forward";
                            else if (ForwardPossible == false)
                            {

                                if (RightPossible == true) Decision = "Right";
                                if (LeftPossible == true) Decision = "Left";

                            }

                        }
                    
                        if (FacingRight == true)
                        {
                        
                            if (BackwardPossible == true) Decision = "Backward";
                            else if (BackwardPossible == false)
                            {

                                if (LeftPossible == true) Decision = "Left";
                                if (RightPossible == true) Decision = "Right";
                            
                            }

                        }
                    
                }
                
                if (CurrentDirect == "Right")
                {
                    
                        if (FacingUp == true)
                        {

                            if (RightPossible == true) Decision = "Right";
                            else if (RightPossible == false)
                            {

                                if (ForwardPossible == true) Decision = "Forward";
                                if (BackwardPossible == true) Decision = "Backward";

                            }

                        }

                        if (FacingDown == true)
                        {
                        
                            if (LeftPossible == true) Decision = "Left";
                            else if (LeftPossible == false)
                            {

                                if (BackwardPossible == true) Decision = "Backward";
                                if (ForwardPossible == true) Decision = "Forward";

                            }

                        }
                    
                        if (FacingLeft == true)
                        {
                        
                            if (BackwardPossible == true) Decision = "Backward";
                            else if (BackwardPossible == false)
                            {

                                if (RightPossible == true) Decision = "Right";
                                if (LeftPossible == true) Decision = "Left";

                            }

                        }
                    
                        if (FacingRight == true)
                        {
                        
                            if (ForwardPossible == true) Decision = "Forward";
                            else if (ForwardPossible == false)
                            {

                                if (LeftPossible == true) Decision = "Left";
                                if (RightPossible == true) Decision = "Right";
                            
                            }

                        }
                    
                }

            }
            
            ReCalc = false;

        }




            //for (int i = 0; i < Available.Count; i++) Debug.Log(Available[i]);
            

            
        





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
            
            if (RageOn == false)Timer = 1.58f;
            if (RageOn == true)Timer = 0.79f;
            ReCalc = true;
            
        }

        if (Check.Rage == true && CheckArea == true)
        {

            PlayerPosition = GameObject.FindWithTag("Player").transform.position;
            EnemyPosition = GameObject.FindWithTag("Enemy").transform.position;
            Debug.Log(PlayerPosition);
            Debug.Log(EnemyPosition);
            RageTimer = 10;
            
            if (EnemyPosition.y > PlayerPosition.y) GoDown = true;
            else if (EnemyPosition.y < PlayerPosition.y) GoUp = true;
            
            if (EnemyPosition.x > PlayerPosition.x) GoLeft = true;
            else if (EnemyPosition.x < PlayerPosition.x) GoRight = true;
            
            
            RageOn = true;
            CheckArea = false;

        }

        if (GameOver.End == true)
        {
            

            Debug.Log("You Died!");
            

        }

    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if (col.tag == "Player")
    //     {
    //         
    //         Debug.Log("Player Spotted");
    //         TestDetect += 1;
    //
    //     }
    // }
}
