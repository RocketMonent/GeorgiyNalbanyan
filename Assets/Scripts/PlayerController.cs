using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public GameObject food;
    private float xRange = 15;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        transform.Translate(Vector3.right * speed * horizontalInput * Time.deltaTime);
      
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, 0, 0);
        }
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, 0, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 offset = new Vector3(0, 1.5f, 1f);
            Vector3 foodSpawnPosition = transform.position + offset;

            Instantiate(food, foodSpawnPosition, food.transform.rotation);
        }
    }
}