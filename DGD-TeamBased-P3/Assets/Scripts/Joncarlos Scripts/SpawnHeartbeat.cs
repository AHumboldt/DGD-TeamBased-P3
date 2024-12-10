
using UnityEngine;

public class SpawnHeartbeat : MonoBehaviour
{
    public GameObject heartbeatRhythm;
    public float spawnRate = 0.79f;
    public float timer = 0;
    void Start()
    {
        Debug.Log("hello");
    }
    void FixedUpdate()
    {
        timer += Time.deltaTime;
        if (timer >= spawnRate){
            Instantiate(heartbeatRhythm,new Vector3(-8.059999f, -3.26f, 0.046094f),Quaternion.identity);
            timer = 0;
        }
    }
}
