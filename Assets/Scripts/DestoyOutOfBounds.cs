using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestoyOutOfBounds : MonoBehaviour
{
    private float topBound = 25;
    private float botBound = -5;

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > topBound)
        {
            Destroy(gameObject);
        }
        
        if (transform.position.z < botBound)
        {
            Destroy(gameObject);
            Debug.Log("Animal escaped!!!");
        }
    }
}
 