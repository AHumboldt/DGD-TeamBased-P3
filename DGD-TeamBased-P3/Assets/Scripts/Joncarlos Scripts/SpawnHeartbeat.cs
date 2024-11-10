
using Unity.VisualScripting;
using UnityEngine;

public class SpawnHeartbeat : MonoBehaviour
{
    public GameObject HeartbeatRhythm;
    public float spawnRate = 0.48f;
    public float timer = 0;
    void Start()
    {
        Debug.Log("hello");
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate){
            Instantiate(HeartbeatRhythm,new Vector3(13, -3.89f, 0.046094f),Quaternion.identity); //transform.position(15, -3.89f, 0.046094f));
            timer = 0;
        }
    }
}
