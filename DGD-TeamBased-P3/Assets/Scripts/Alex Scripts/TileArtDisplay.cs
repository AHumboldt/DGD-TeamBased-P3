using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TileArtDisplay : MonoBehaviour
{
    
    public List<IconInfo> IconsRaw;

    public Sprite FDoor;
    public Sprite LDoor;
    public Sprite RDoor;
    public Sprite FLDoor;
    public Sprite FRDoor;
    public Sprite LRDoor;
    public Sprite FLRDoor;

    public SpriteRenderer ThisRoom;
    
    private CheckForward FCheck;
    private CheckBackwards BCheck;
    private CheckLeft LCheck;
    private CheckRight RCheck;

    public bool ForwardDoor;
    public bool LeftDoor;
    public bool RightDoor;
    
    //Have room detectors ON the player Check Up/Right/Left/Down
    //Depending on the direction that checks, it shows the forward, backward, left, or right version of said room
    //To do that: the possible routes to take will be in a list

    void Start()
    {
        
        FCheck = GameObject.FindWithTag("FTCheck").GetComponent<CheckForward>();
        BCheck = GameObject.FindWithTag("BTCheck").GetComponent<CheckBackwards>();
        LCheck = GameObject.FindWithTag("LTCheck").GetComponent<CheckLeft>();
        RCheck = GameObject.FindWithTag("RTCheck").GetComponent<CheckRight>();
        
    }

    void Update()
    {
        
        if (FCheck.Detect == true) ForwardDoor = true;
        if (FCheck.Detect == false) ForwardDoor = false;
        
        if (LCheck.Detect == true) LeftDoor = true;
        if (LCheck.Detect == false) LeftDoor = false;
        
        if (RCheck.Detect == true) RightDoor = true;
        if (RCheck.Detect == false) RightDoor = false;



        if (ForwardDoor == true && LeftDoor == false && RightDoor == false) ThisRoom.sprite = FDoor;
        if (ForwardDoor == false && LeftDoor == true && RightDoor == false) ThisRoom.sprite = LDoor;
        if (ForwardDoor == false && LeftDoor == false && RightDoor == true) ThisRoom.sprite = RDoor;
        if (ForwardDoor == true && LeftDoor == true && RightDoor == false) ThisRoom.sprite = FLDoor;
        if (ForwardDoor == true && LeftDoor == false && RightDoor == true) ThisRoom.sprite = FRDoor;
        if (ForwardDoor == false && LeftDoor == true && RightDoor == true) ThisRoom.sprite = LRDoor;
        if (ForwardDoor == true && LeftDoor == true && RightDoor == true) ThisRoom.sprite = FLRDoor;

    }

    [System.Serializable]
    public class IconInfo
    {
        public string Name;
        public Sprite S;
    }
    
}
