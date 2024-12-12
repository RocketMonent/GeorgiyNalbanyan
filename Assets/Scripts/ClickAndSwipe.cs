using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider), typeof(TrailRenderer))]
public class ClickAndSwipe : MonoBehaviour
{
    private BoxCollider boxCollider;
    private TrailRenderer trail;
    private Vector3 mousePosition;
    private GameManager gameManager;

    private bool isSwiping;

    private void Awake()
    {
        boxCollider = GetComponent<BoxCollider>();
        trail = GetComponent<TrailRenderer>();
        gameManager = FindObjectOfType<GameManager>();


        boxCollider.enabled = false;
        trail.enabled = false;
    }

    private void UpdateMousePosition()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
        transform.position = mousePosition;
    }

    private void UpdateCommponents()
    {
        boxCollider.enabled = isSwiping;
        trail.enabled = isSwiping;
    }

    private void Update()
    {
        if (gameManager.isGameActive)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isSwiping = true;
                UpdateCommponents();
            }

            else if (Input.GetMouseButtonUp(0))
            {
                isSwiping = false;
                UpdateCommponents();
            }
        }

        if (isSwiping)
        {
            UpdateMousePosition();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Target target))
        {
            target.DestroyTarget();
        }
    }
}
