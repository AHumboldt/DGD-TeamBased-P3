using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseBehaviorTest : MonoBehaviour
{
    public AudioSource aS;
    public AudioClip ac;
    public bool beingChased = true;

    public float timer = 0;
    public float spawnRate = 0.79f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            beingChased = true;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            beingChased = false;
        }
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;

        if (beingChased == true)
        {
            if (timer >= spawnRate)
            {
                aS.PlayOneShot(ac);
                timer = 0;
                Debug.Log("SoundPlaying");
            }
        }
        else if (beingChased == false)
            if (timer >= spawnRate)
            {
                timer = 0;
            }
    }
}
