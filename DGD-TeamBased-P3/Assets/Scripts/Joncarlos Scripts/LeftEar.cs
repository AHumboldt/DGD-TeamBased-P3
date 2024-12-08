using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LeftEar : MonoBehaviour
{
    public GameObject enemy;
    public GameObject player;

    public MonsterHeart MonsterHeart;
    // Start is called before the first frame update
    void Start()
    {
        enemy = GameObject.FindWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    private void OnTriggerEnter2D(Collider2D Enemy)
    {

        if (Enemy.tag == "Enemy")
        {
            MonsterHeart.Heart.enabled = true;
            MonsterHeart.Heart.panStereo = -0.75f;
        }

    }
    // private void OnTriggerExit2D(Collider2D Enemy)
    // {
    //
    //     if (Enemy.tag == "Enemy")
    //     {
    //         MonsterHeart.Heart.enabled = false;
    //         MonsterHeart.Heart.panStereo = 0;
    //     }
    //
    // }
}
