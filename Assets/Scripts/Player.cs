using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;

    private bool isWalking;

    public bool IsWalking => isWalking;
    
    private void Update()
    {
        Vector2 inputVector2 = new Vector2(0, 0);

        if (Input.GetKey(KeyCode.W))
        {
            inputVector2.y = +1;
        }

        if (Input.GetKey(KeyCode.S))
        {
            inputVector2.y = -1;
        }

        if (Input.GetKey(KeyCode.A))
        {
            inputVector2.x = -1;
        }

        if (Input.GetKey(KeyCode.D))
        {
            inputVector2.x = +1;
        }

        inputVector2 = inputVector2.normalized;

        Vector3 moveDirection = new Vector3(inputVector2.x, 0, inputVector2.y);

        isWalking = moveDirection != Vector3.zero;

        transform.position += moveDirection * Time.deltaTime * moveSpeed;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);

    }
}