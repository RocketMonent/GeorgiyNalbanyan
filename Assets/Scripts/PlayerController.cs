using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 15;
    public float rotationSpeed = 15;
    public Camera firstPersonCamera;
    public Camera thirdPersonCamera;


    // Start is called before the first frame upsdate
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * speed * Time.deltaTime * forwardInput);
        transform.Rotate(Vector3.up, horizontalInput * Time.deltaTime * rotationSpeed);
    }
}
 