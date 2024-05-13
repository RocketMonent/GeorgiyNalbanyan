using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private PlayerController player;
    private float speed = 30f;
    private float leftbound = -15;
    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (player.isGameOver == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }

        if (transform.position.x < leftbound)
        {
            Destroy(gameObject);
        }
    }
}