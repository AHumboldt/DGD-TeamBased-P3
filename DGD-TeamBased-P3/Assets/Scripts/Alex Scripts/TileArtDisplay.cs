using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileArtDisplay : MonoBehaviour
{
    
    public List<IconInfo> IconsRaw;
    
    [System.Serializable]
    public class IconInfo
    {
        public string Name;
        public Sprite S;
    }
    
}
