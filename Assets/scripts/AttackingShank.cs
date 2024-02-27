using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class AttackingShank : MonoBehaviour
{
    public TargetScript targetScript;

    public bool shankVisible;
    private bool canKill;

    public float attackRange = 2f;

    public string enemyTag = "Enemy";

    public TextMeshPro killText;

    public GameObject shank;

    public float shankVisibleTime = 0f;

    void Start()
    {
        shankVisible = false;

        killText.enabled = false;

        canKill = false;

        shank.SetActive(false);
    }

    void Update()
    {
        Debug.Log("AttackingShank Update");

        Debug.Log("shankVisibleTime: " + shankVisibleTime.ToString("F0"));

        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            EmptyHand();
        }

        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            EquiptShank();
        }

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);

        foreach (GameObject enemy in enemies)
        {
            float distancetoEnemy = Vector3.Distance(transform.position, enemy.transform.position);

            if (distancetoEnemy < targetScript.viewRange)
            {
                if (shankVisible)
                {
                    shankVisibleTime += Time.deltaTime;

                    canKill = true;

                    if (Input.GetKeyDown(KeyCode.F))
                    {
                        targetScript.isAlive = false;
                    }
                }

                killText.enabled = true;
            }
            else if (distancetoEnemy > attackRange)
            {
                canKill = false;

                killText.enabled = false;

                shankVisibleTime = 0f;
            }
        }
    }
    private void EmptyHand()
    {
        shankVisible = false;

        shank.SetActive(false);

        if (shankVisibleTime < 4)
        {
            shankVisibleTime = 0f;
        }
    }

    private void EquiptShank()
    {
        shankVisible = true;

        shank.SetActive(true);
    }
}
