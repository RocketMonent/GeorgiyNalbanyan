using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;

    private Rigidbody rigidbody;
    private PlayerController player;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerController>();

    }

    private void Update()
    {
        Vector3 moveDirection = (player.transform.position - transform.position).normalized;
        rigidbody.AddForce(moveDirection * speed);

        if (transform.position.y < -5)
        {
            Destroy(gameObject);
        }
    }
}
