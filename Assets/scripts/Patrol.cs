//using UnityEngine;
//using UnityEngine.AI;

//public class Patrol : MonoBehaviour
//{
//    public TargetScript targetScript;
//    public AttackingShank attackingShank;

//    public Transform[] waypoints;
//    private int currentWaypointIndex;

//    private float waitTime = 3f;
//    private float waitCounter = 0;
//    private bool waiting = false;

//    private NavMeshAgent navMeshAgent;

//    void Start()
//    {
//        navMeshAgent = GetComponent<NavMeshAgent>();
//        navMeshAgent.speed = targetScript.moveSpeed;
//    }

//    void Update()
//    {
//        if (targetScript.alert == false)
//        {
//            if (targetScript.isAlive == true)
//            {
//                if (targetScript.startled == false)
//                {
//                    if (attackingShank.shankVisibleTime == 0f)
//                    {
//                        PatrolPlz();
//                    }
//                }
//            }
//        }
//    }

//    public void PatrolPlz()
//    {
//        if (waiting || targetScript.startled)
//        {
//            waitCounter += Time.deltaTime;

//            if (waitCounter < waitTime)
//                return;

//            waiting = false;
//        }
//        else
//        {
//            Transform wp = waypoints[currentWaypointIndex];

//            if (Vector3.Distance(transform.position, wp.position) < 1f)
//            {
//                waitCounter = 0;
//                waiting = true;
//                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
//            }
//            else
//            {
//                navMeshAgent.SetDestination(wp.position);
//            }
//        }
//    }
//}