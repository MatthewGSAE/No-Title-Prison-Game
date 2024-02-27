using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class TargetScript : MonoBehaviour
{
    public AttackingShank attackingShank;
    //public Patrol patrol;
    public Routine routine;

    public Transform player;

    public float moveSpeed = 4;
    public float rotationSpeed = 2;
    public float viewRange = 10;
    public float fieldOfView = 60;

    public bool isAlive = true;
    public bool startled = false;
    public bool alert = false;

    private NavMeshAgent navMeshAgent;

    private GameObject guardObject;

    //public SpriteRenderer spriteRenderer;
    //public float fadeDuration = 2f;

    void Start()
    {
        isAlive = true;

        startled = false;

        alert = false;

        guardObject = GameObject.FindGameObjectWithTag("Guard");

        navMeshAgent = GetComponent<NavMeshAgent>();
        navMeshAgent.speed = moveSpeed;
    }

    void Update()
    {
        if (alert)
        {
            FindGuardAndRun();
        }
        if (!alert)
        {
            if (isAlive)
            {
                if (IsPlayerInSight())
                {
                    if (attackingShank.shankVisible == true)
                    {
                        BecomeStartled();

                        Debug.Log("Becoming startled");
                    }

                    if (attackingShank.shankVisibleTime >= 4f)
                    {
                        if (!alert)
                        {
                            Alert();
                        }
                    }
                    else if (attackingShank.shankVisibleTime == 0f)
                    {
                        if (!alert)
                        {
                            CalmingDown();
                        }
                    }
                }
            }
            else if (!isAlive)
            {
                Die();
            }
        }
    }

    private bool IsPlayerInSight()
    {
        Vector3 toPlayer = player.position - transform.position;
        float angleToPlayer = Vector3.Angle(transform.forward, toPlayer);

        if (angleToPlayer < fieldOfView * 0.5f)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, toPlayer, out hit, viewRange))
            {
                if (hit.collider.CompareTag("Player"))
                {
                    return true;
                }
            }
        }

        return false;
    }
    private void BecomeStartled()
    {
        moveSpeed = 0;

        startled = true;

        transform.LookAt(player.position);
    }

    public void Alert()
    {
        alert = true;
        Debug.Log("Alerted");
        moveSpeed = 5;
        FindGuardAndRun();
    }

    private void FindGuardAndRun()
    {
        GameObject[] guardObjects = GameObject.FindGameObjectsWithTag("Guard");

        float closestDistance = float.MaxValue;
        GameObject closestGuard = null;

        foreach (GameObject guard in guardObjects)
        {
            float distance = Vector3.Distance(transform.position, guard.transform.position);
            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestGuard = guard;
            }
        }

        if (closestGuard != null && closestDistance > 1.0f)
        {
            navMeshAgent.SetDestination(closestGuard.transform.position);
        }
    }

    private void CalmingDown()
    {
        Debug.Log("Calming down");
        startled = false;
        alert = false;
    }

    private void Die()
    {
        moveSpeed = 0;
        isAlive = false;
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
    }
}

//IEnumerator FadeInWarning()
//{
//    float elapsedTime = 0f;
//    Color startColor = spriteRenderer.color;
//    Color targetColor = new Color(startColor.r, startColor.g, startColor.b, 1f);

//    while (elapsedTime < fadeDuration)
//    {
//        spriteRenderer.color = Color.Lerp(startColor, targetColor, elapsedTime / fadeDuration);
//        elapsedTime += Time.deltaTime;
//        yield return null;
//    }

//    spriteRenderer.color = targetColor;
//}
