using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public PlayerController player;
    public Obstacle obstaclePrefab;
    private Vector3 spawnPos = new Vector3(25, 0, 0);
    private float startDelay = 2;
    private float repeatRate = 2;

    void Start()
    {
        InvokeRepeating("SpawnObstacle", startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        if (!player.isGameOver)
        {
            Instantiate(obstaclePrefab, spawnPos, obstaclePrefab.transform.rotation);
        }
    }
}
    