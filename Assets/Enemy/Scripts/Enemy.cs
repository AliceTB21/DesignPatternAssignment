using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : Unit
{
    [Header("Attack")]
    [SerializeField] protected float attackRange = 3f;
    [SerializeField] protected float attackSpeed;
    [SerializeField] protected Transform target;
    [Header("Agent")]
    [SerializeField] protected NavMeshAgent agent;
    [SerializeField] protected float idleTimer;
    [SerializeField] protected Transform unitPos;
    [SerializeField] protected bool isWaiting = true;

    protected Vector3 posToMove;

    protected enum EnemyState { Idle, Wandering, MoveToTarget, Attacking}

    public Transform GetUnitPos { get { return unitPos; } }

    protected virtual void UpdateState(Transform unitPos)
    {

    }

    protected virtual void DecideAction(EnemyState state)
    {


        switch(state)
        {
            case EnemyState.Idle:
                Debug.Log("Idle");
            break;

            case EnemyState.Wandering:
                Debug.Log("Wandering");
                posToMove = GetRandomPosition();
                agent.SetDestination(posToMove);
                break;

            case EnemyState.MoveToTarget:
                Debug.Log("Move to target");
                if (target)
                {
                    agent.SetDestination(target.position);
                    isWaiting = false;
                }
                else
                    isWaiting = true;

                break;

            case EnemyState.Attacking:
                Debug.Log("Attacking");
                break;
        }
    }

    private void Start()
    {
        if (agent == null)
            agent = GetComponent<NavMeshAgent>();

        UpdateState(GetUnitPos);
    }

    private void Update()
    {
        if(idleTimer > 0 && isWaiting)
        {
            idleTimer -= Time.deltaTime;
            idleTimer = Mathf.Clamp(idleTimer, 0, Mathf.Infinity);

            if(idleTimer <= 0)
            {
                isWaiting = false;

            }
        }
        UpdateState(GetUnitPos);
    }

    protected Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(-50f, 50f), 0, Random.Range(-50f, 50f));
    }

    protected float RandomTimer(float minTime, float maxTime)
    {
        return Random.Range(minTime, maxTime);
    }

    protected virtual void GetInfo()
    {

    }
}
