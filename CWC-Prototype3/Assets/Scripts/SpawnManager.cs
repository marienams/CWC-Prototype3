using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject obstacle;
    public float spawnInterval;
    private PlayerController playerControlScript;
    // Start is called before the first frame update
    void Start()
    {
        playerControlScript = GameObject.Find("Player").GetComponent<PlayerController>();
        InvokeRepeating("SpawnObstacle", 2.0f, spawnInterval);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void SpawnObstacle()
    {
        if(playerControlScript.gameOver == false)
        {
            Instantiate(obstacle, transform.position, transform.rotation);
        }
        
        // currently taking the obstacle, instantiating them in th position and rotation of spawn manager
    }
}
