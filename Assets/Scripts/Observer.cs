using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Observer : MonoBehaviour
{
    public Player player;
    public GameEnding gameEnding;

    private bool isPlayerInRange;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform == player.transform)
        {
            isPlayerInRange = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.transform == player.transform)
        {
            isPlayerInRange = false;
        }
    }

    private void Update()
    {
        if (isPlayerInRange == true)
        {
            Vector3 direction = player.transform.position - transform.position + Vector3.up;
            Ray ray = new Ray(transform.position, direction);

            if (Physics.Raycast(ray,out RaycastHit raycastHit))
            {
                if (raycastHit.transform == player.transform)
                {
                    gameEnding.CaughtPlayer();
                }
            }
        }
    }
}
