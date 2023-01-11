using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyBehaviour : MonoBehaviour
{
    protected Rigidbody2D _rigidbody;
    [SerializeField] protected GameObject _targetToSeek;
    [SerializeField] protected float _distanceToStop;

    [SerializeField] protected float _movementSpeed;
    protected Vector2 _movementVector;

    [SerializeField] protected string _pathShootCannonBall;

    public GameObject targetToSeek { get => _targetToSeek; set => _targetToSeek = value; }

    protected virtual void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    protected virtual void Update()
    {
        CalculateMovement();
    }

    protected virtual void FixedUpdate() { }

    protected void CalculateMovement()
    {
        Vector3 _directionVector = _targetToSeek.transform.position - transform.position;
        float _angleDirection = Mathf.Atan2(-_directionVector.x, _directionVector.y) * Mathf.Rad2Deg;
        _rigidbody.rotation = _angleDirection;
        _directionVector.Normalize();
        _movementVector = _directionVector;
    }

    protected void MoveToTarget(Vector2 directionVector)
    {
        _rigidbody.MovePosition((Vector2)transform.position + (directionVector * _movementSpeed * Time.fixedDeltaTime));
    }
}
