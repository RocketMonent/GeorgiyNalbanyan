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

        float moveDistance = moveSpeed * Time.deltaTime;
        float playerRadius = 0.7f;
        float playerHight = 2f;
        bool canMove = !Physics.CapsuleCast(transform.position,transform.position + Vector3.up * playerRadius,playerRadius, moveDirection, moveDistance);

        if (canMove == false)
        {
            Vector3 moveDirectionX = new Vector3(moveDirection.x, 0, 0).normalized;
            canMove = !Physics.CapsuleCast(transform.position, transform.position + Vector3.up * playerRadius, playerRadius, moveDirectionX, moveDistance);
            if (canMove == true)
            {
                moveDirection = moveDirectionX;
            }
            else
            {
                Vector3 moveDirectionZ = new Vector3(0, 0, moveDirection.z).normalized;
                canMove = !Physics.CapsuleCast(transform.position, transform.position = Vector3.up * playerRadius, playerRadius, moveDirectionZ, moveDistance);
                if (canMove == true)
                {
                    moveDirection = moveDirectionZ;
                }
            }
        }
        
        if (canMove == true)
        {
            transform.position += moveDirection * moveDistance;
        }

        transform.forward = Vector3.Slerp(transform.forward, moveDirection, Time.deltaTime * rotationSpeed);

    }
}