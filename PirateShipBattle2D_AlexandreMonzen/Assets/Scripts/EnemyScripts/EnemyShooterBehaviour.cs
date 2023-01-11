using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class EnemyShooterBehaviour : EnemyBehaviour
{
    [SerializeField] private float _timeToShoot;
    [SerializeField] private Transform _offsetSingleShoot;

    [SerializeField] private float _distanceToShoot;

    private float _timer;

    protected override void Awake()
    {
        base.Awake();
        _timer = 0;
    }

    protected override void Update()
    {
        base.Update();

        _timer += 1 * Time.deltaTime;
    }

    protected override void FixedUpdate()
    {
        float distanceVector = Vector3.Distance(transform.position, _targetToSeek.transform.position);

        if (distanceVector <= _distanceToShoot)
        {
            ShootAtTarget();
        }
        else if(distanceVector > _distanceToStop && distanceVector < _distanceToShoot)
        {
            ShootAtTarget();
            MoveToTarget(_movementVector);
        }
        
        if(distanceVector > _distanceToStop)
        {
            MoveToTarget(_movementVector);
        }
    }

    private void ShootAtTarget()
    {
        if (_timer >= _timeToShoot)
        {
            _timer = 0;

            GameObject cannonBall = ObjectPooler.SharedInstance.GetPooledUpEnemyCannonBall();
            cannonBall.transform.position = _offsetSingleShoot.position;
            cannonBall.transform.rotation = _offsetSingleShoot.rotation;
            cannonBall.SetActive(true);

            FMODUnity.RuntimeManager.PlayOneShot(_pathShootCannonBall);
        }
    }
}
