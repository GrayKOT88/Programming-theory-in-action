using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] obstaclePrefabs;
    private PlayerController playerControllerScript;
    private int spawnRangeZ = 3;

    void Start()
    {
        InvokeRepeating("SpawnRandomObstracl", 2, 1.5f);
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    void SpawnRandomObstracl()
    {
        Vector3 spawnPos = new Vector3(29, 0, Random.Range(-spawnRangeZ,spawnRangeZ));
        int obstacleIndex = Random.Range(0, obstaclePrefabs.Length);
        if (playerControllerScript.gameOver == false)
        {
            Instantiate(obstaclePrefabs[obstacleIndex], spawnPos, obstaclePrefabs[obstacleIndex].transform.rotation);
        }
    }
}
