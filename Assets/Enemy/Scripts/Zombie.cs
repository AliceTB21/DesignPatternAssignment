using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : Enemy
{
    EnemyState state;
    

    protected override void UpdateState(Transform unitPos)
    {
        if (target != null)
        {
            float distanceToTarget = (unitPos.transform.position - target.position).magnitude;
        }

        switch(state)
        {
            case EnemyState.Idle:
                if (idleTimer == 0 && isWaiting)
                {
                    idleTimer = RandomTimer(5, 10);
                    isWaiting = false;
                }
                else if (idleTimer <= 0)
                {
                    state = EnemyState.Wandering;
                    idleTimer = 0;
                    isWaiting = true;
                }
                break;
            case EnemyState.Wandering:
                if(agent.velocity.magnitude < 1)
                {
                    state = EnemyState.Idle;
                }
                break;
            case EnemyState.MoveToTarget:

                break;
            case EnemyState.Attacking:

                break;

        }

        DecideAction(state);

    }
}
