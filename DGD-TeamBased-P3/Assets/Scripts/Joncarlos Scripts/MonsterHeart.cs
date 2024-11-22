using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterHeart : MonoBehaviour
{

    public AudioSource Heart;

    public bool AudioPlaying = false;

    public bool SoundEnter = false;
    // Start is called before the first frame update
    void Start()
    {
        Heart = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Heart.enabled == true && AudioPlaying == false)
        {
            Heart.Play();
            AudioPlaying = true;
        }

        if (Heart.enabled == false)
        {
            AudioPlaying = false;
        }
    }
}
