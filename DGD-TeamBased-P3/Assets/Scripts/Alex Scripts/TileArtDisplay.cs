using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileArtDisplay : MonoBehaviour
{
    
    public List<IconInfo> IconsRaw;
    
    //Have room detectors ON the player Check Up/Right/Left/Down
    //Depending on the direction that checks, it shows the forward, backward, left, or right version of said room
    //To do that: the possible routes to take will be in a list
    //
    
    [System.Serializable]
    public class IconInfo
    {
        public string Name;
        public Sprite S;
    }
    
}
