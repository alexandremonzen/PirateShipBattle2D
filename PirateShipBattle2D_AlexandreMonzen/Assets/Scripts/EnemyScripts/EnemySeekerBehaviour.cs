using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemySeekerBehaviour : EnemyBehaviour
{
    protected override void FixedUpdate()
    {
        float distanceVector = Vector3.Distance(transform.position, _targetToSeek.transform.position);

        if (distanceVector >= _distanceToStop)
        {
            MoveToTarget(_movementVector);
        }
        else
        {
            
        }
    }
}
