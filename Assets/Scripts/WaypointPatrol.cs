using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class WaypointPatrol : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;
    public Transform[] wayPointsArray;

    private int currentWaypointIndex;

    private void Start()
    {
        navMeshAgent.SetDestination(wayPointsArray[0].position);
    }

    private void Update()
    {
        if (navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % wayPointsArray.Length;
            navMeshAgent.SetDestination(wayPointsArray[currentWaypointIndex].position); 
        }
    }
}
