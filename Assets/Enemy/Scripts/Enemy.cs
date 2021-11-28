using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    [SerializeField] protected float attackRange = 3f;
    [SerializeField] protected float attackSpeed;
    [SerializeField] Unit targetToAttack;
    [SerializeField] protected Transform target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] protected float idleTimer;

    private void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        if(idleTimer > 0)
        {
            idleTimer -= Time.deltaTime;

            if(idleTimer <= 0)
            {
                Debug.Log("Moving to random position");
            }
        }
    }

    protected Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
    }

    protected float RandomTimer(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }
}
