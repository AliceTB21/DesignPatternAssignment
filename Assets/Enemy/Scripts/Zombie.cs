using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    EnemyState state;
    protected override void GetInfo()
    {
        if(target)
        Debug.Log(target.position);
    }

    protected override void UpdateState(Transform playerPos)
    {
        float distanceToTarget = 0;
        if(target)
            distanceToTarget = (transform.position - target.position).magnitude;

        switch(state)
        {
            case EnemyState.Idle:
                if (idleTimer == 0 && isWaiting)
                {
                    idleTimer = RandomTimer(5, 10);
                }
                else if (target)
                    state = EnemyState.MoveToTarget;
                else if (idleTimer <= 0)
                {
                    state = EnemyState.Wandering;
                    idleTimer = 0;

                }
                break;
            case EnemyState.Wandering:
                if(agent.velocity.magnitude < 1)
                {
                    isWaiting = true;
                    state = EnemyState.Idle;
                }
                else if (target)
                    state = EnemyState.MoveToTarget;
                break;
            case EnemyState.MoveToTarget:
                if(distanceToTarget > maxDetectionRage)
                {
                    isWaiting = true;
                    idleTimer = RandomTimer(5, 10);
                    state = EnemyState.Idle;
                    target = null;
                }
                
                if (distanceToTarget < attackRange)
                {
                    agent.isStopped = true;
                }
                else
                    agent.isStopped = false;

                break;
            case EnemyState.Attacking:

                break;

        }

        DecideAction(state);

    }
}
