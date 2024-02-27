using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class GuardPatrol : MonoBehaviour
{
    public AttackingShank attackingShank;

    private float moveSpeed = 4;

    private NavMeshAgent navMeshAgent;

    private float waitTime = 3f;
    private float waitCounter = 0;
    private bool waiting = false;

    public Transform[] waypoints;
    private int currentWaypointIndex;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
    }

    void Update()
    {
        GuardPatrolling();
    }

    private void GuardPatrolling()
    {
            if (waiting)
            {
                waitCounter += Time.deltaTime;

                if (waitCounter < waitTime)
                    return;

                waiting = false;
            }
            else
            {
                Transform wp = waypoints[currentWaypointIndex];

                if (Vector3.Distance(transform.position, wp.position) < 1f)
                {
                    waitCounter = 0;
                    waiting = true;
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                }
                else
                {
                    navMeshAgent.SetDestination(wp.position);
                }
            }
    }
}
