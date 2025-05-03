using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed;

    private Vector3 movementDirection;
    private Quaternion rotation;

    private Animator animator;
    private Rigidbody rigidbody;
    private AudioSource audioSource;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        movementDirection.Set(horizontalInput, 0, verticalInput);
        movementDirection.Normalize();

        bool hasHorizontalInput = !Mathf.Approximately(horizontalInput, 0);
        bool hasVerticalInput = !Mathf.Approximately(verticalInput, 0);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        animator.SetBool("IsWalking", isWalking);
        if (isWalking == true)
        {
            if (audioSource.isPlaying == false)
            {
                audioSource.Play();
            }
        }
        else
        {
            audioSource.Stop();
        }

        Vector3 desierdForward = Vector3.RotateTowards(transform.forward, movementDirection, turnSpeed * Time.deltaTime, 0);
        rotation = Quaternion.LookRotation(desierdForward);
    }

    private void OnAnimatorMove()
    {
        rigidbody.MovePosition(rigidbody.position + movementDirection * animator.deltaPosition.magnitude);
        rigidbody.MoveRotation(rotation);
    }
}