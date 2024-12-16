using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviorTest : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip ac;
    public bool beingChased = false;

    public AudioSource MainMusic;
    public AudioSource ChaseMusic;

    public EnemyMovement EM;

    public float timer = 0;
    public float spawnRate = 0.79f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // if (Input.GetKeyDown(KeyCode.D))
        // {
        //     beingChased = true;
        // }
        //
        // if (Input.GetKeyDown(KeyCode.S))
        // {
        //     beingChased = false;
        // }

        if (EM.RageOn == true)
        {
            beingChased = true;
        }
        if (EM.RageOn == false)
        {
            beingChased = false;
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (beingChased == true)
        {
            MainMusic.volume = 0;
            ChaseMusic.volume = 1;
            if (timer >= spawnRate)
            {
                aS.PlayOneShot(ac);
                timer = 0;
                Debug.Log("SoundPlaying");
            }
        }
        else if (beingChased == false)
        {
            MainMusic.volume = 1;
            ChaseMusic.volume = 0;
            
            if (timer >= spawnRate)
            {
                timer = 0;
            }
        }
    }
}
