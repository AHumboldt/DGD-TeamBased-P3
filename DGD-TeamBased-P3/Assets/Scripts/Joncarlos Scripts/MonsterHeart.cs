using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHeart : MonoBehaviour
{
    public float xDistance;
    public float yDistance;
    
    public Animator HeartPulse;
    
    public GameObject enemy;
    public GameObject player;
    public AudioSource Heart;

    public bool AudioPlaying = false;

    public bool SoundEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        Heart = GetComponent<AudioSource>();
        HeartPulse.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Heart.enabled == true && AudioPlaying == false)
        {
            Heart.Play();
            AudioPlaying = true;
            HeartPulse.enabled = true;
        }

        if (Heart.enabled == false)
        {
            AudioPlaying = false;
        }
        
        xDistance = Mathf.Abs(enemy.transform.position.x - player.transform.position.x);
        yDistance = Mathf.Abs(enemy.transform.position.y - player.transform.position.y);
        if (xDistance >= 5 || yDistance >= 5)
        {
            Heart.enabled = false;
            HeartPulse.enabled = false;
        }
        // if (Vector3.Distance(enemy.transform.position, player.transform.position) < 3)
        // {
        //     Debug.Log("I am close");
        // };
    }
}
