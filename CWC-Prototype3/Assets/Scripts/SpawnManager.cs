using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnInterval;
    private Vector3 spawnPos = new Vector3(37f, 1.5f, 0.3f);
    private PlayerController playerControlScript;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnObstacle", 2.0f, spawnInterval);
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnObstacle()
    {
        if(playerControlScript.gameOver == false)
        {
            Instantiate(obstacle, spawnPos, obstacle.transform.rotation);
            Debug.Log("Obstacle created");
        }
        
        // currently taking the obstacle, instantiating them in th position and rotation of spawn manager
    }
}
