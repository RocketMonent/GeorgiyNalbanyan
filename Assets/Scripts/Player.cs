using System;
using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveSpeed;
    [SerializeField] private float rotationSpeed;
    [SerializeField] private GameInput gameInput; 

    private bool isWalking;

    public bool IsWalking => isWalking;
    
    private void Update()
    {
        Vector2 inputVector = gameInput.GetMovementVector();
        
        Vector3 moveDirection = new Vector3(inputVector.x, 0, inputVector.y);

        isWalking = moveDirection != Vector3.zero;

        transform.position += moveDirection * Time.deltaTime * moveSpeed;

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);

    }
}