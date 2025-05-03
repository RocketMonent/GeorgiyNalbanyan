using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeySpawner : MonoBehaviour
{
    public Key keyPrefab;
    public List<Transform> spawnPoints;

    private void Start()
    {
        Spawn();
    }
    private void Spawn()
    {
        int randomPoint = Random.Range(0, spawnPoints.Count);
        Instantiate(keyPrefab, spawnPoints[randomPoint].position, Quaternion.identity);
    }
}