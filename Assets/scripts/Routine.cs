using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Routine : MonoBehaviour
{
    public TargetScript targetScript;

    public bool one1 = false;
    public bool two1 = false;
    public bool three1 = false;
    public bool four1 = false;
    public bool five1 = false;
    public bool six1 = false;
    public bool seven1 = false;
    public bool eight1 = false;
    public bool nine1 = false;
    public bool ten1 = false;
    public bool eleven1 = false;
    public bool twelve1 = false;
    public bool one2 = false;
    public bool two2 = false;
    public bool three2 = false;
    public bool four2 = false;
    public bool five2 = false;
    public bool six2 = false;
    public bool seven2 = false;
    public bool eight2 = false;
    public bool nine2 = false;
    public bool ten2 = false;
    public bool eleven2 = false;
    public bool twelve2 = false;

    private GameObject hallway;
    private GameObject dinningArea;
    private GameObject gym;
    private GameObject shower;

    private NavMeshAgent navMeshAgent;

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = targetScript.moveSpeed;
    }
    // Update is called once per frame
    void Update()
    {
        CheckTime();

        FindTarget();
    }

    private void CheckTime()
    {
        if (twelve2 || one1 || two1 || three1 || four1 || five1 || six1 || seven1)
        {
            LockDown();
        }
        if (eight1)
        {
            RollCall();
        }
        if (nine1)
        {
            Breakfast();
        }
        if (ten1 || eleven1)
        {
            FreeTime();
        }
        if (twelve1)
        {
            LunchTime();
        }
        if (one2 || two2)
        {
            JobTime();
        }
        if (three2)
        {
            Exercise();
        }
        if (four2)
        {
            Shower();
        }
        if (five2 || six2)
        {
            FreeTime();
        }
        if (seven2)
        {
            DinnerTime();
        }
        if (eight2 || nine2)
        {
            FreeTime();
        }
        if (ten2)
        {
            RollCall();
        }
        if (eleven2)
        {
            BedTime();
        }
    }

    private void FindTarget()
    {
        hallway = GameObject.FindGameObjectWithTag("Hallway");
        shower = GameObject.FindGameObjectWithTag("Shower");
        gym = GameObject.FindGameObjectWithTag("Gym");
        dinningArea = GameObject.FindGameObjectWithTag("DinningArea");
    }

    private void LockDown()
    {
        Debug.Log("its lock down time");
    }

    private void RollCall()
    {
        Debug.Log("Rollcall");

        navMeshAgent.SetDestination(hallway.transform.position);
    }

    private void Breakfast()
    {
        Debug.Log("breakfast time");

        navMeshAgent.SetDestination(dinningArea.transform.position);
    }

    private void FreeTime()
    {
        Debug.Log("freetime");
    }

    private void LunchTime()
    {
        Debug.Log("lunch time");

        navMeshAgent.SetDestination(dinningArea.transform.position);
    }

    private void JobTime()
    {
        Debug.Log("job time");
    }

    private void Exercise()
    {
        Debug.Log("exercise time");

        navMeshAgent.SetDestination(gym.transform.position);
    }

    private void Shower()
    {
        Debug.Log("hsower time");

        navMeshAgent.SetDestination(shower.transform.position);
    }

    private void DinnerTime()
    {
        Debug.Log("dinner time");

        navMeshAgent.SetDestination(dinningArea.transform.position);
    }

    private void BedTime()
    {
        Debug.Log("bed time");
    }
}
