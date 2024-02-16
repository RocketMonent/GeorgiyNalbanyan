using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] animals;

    private int xSpawnRange = 14;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            int randomAnimal = Random.Range(0, animals.Length);
            Vector3 randomPosition = new Vector3(Random.Range(-xSpawnRange, xSpawnRange), 0, 20);
            Instantiate(animals[randomAnimal], randomPosition, animals[randomAnimal].transform.rotation);        
        }
    }
}
