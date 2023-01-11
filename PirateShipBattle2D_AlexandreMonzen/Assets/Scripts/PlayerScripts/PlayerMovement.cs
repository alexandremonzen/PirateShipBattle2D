using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerMovement : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    private InputAction _movementInputAction;
    private InputAction _rotationInputAction;
    private Rigidbody2D _rigidbody;

    private Vector2 _movementVector;
    private Vector2 _rotationVector;

    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _rotationSpeed;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
        _rigidbody = GetComponent<Rigidbody2D>();

        _movementVector = Vector2.zero;
        _rotationVector = Vector2.zero;
    }

    private void Start()
    {
        
    }

    private void OnEnable()
    {
        _movementInputAction = _playerInputActions.Player.Movement;
        _movementInputAction.Enable();

        _rotationInputAction = _playerInputActions.Player.Rotation;
        _rotationInputAction.Enable();
    }

    private void OnDisable()
    {
        _movementInputAction.Disable();
        _rotationInputAction.Disable();
    }

    private void Update()
    {
        HandleMovement();
        HandleRotation();
    }

    private void FixedUpdate()
    {
        HandleMovementPhysics();
        HandleRotationPhysics();
    }

    private void HandleMovement()
    {
        _movementVector = _movementInputAction.ReadValue<Vector2>();
    }

    private void HandleMovementPhysics()
    {
        _rigidbody.AddRelativeForce(_movementVector * _movementSpeed, ForceMode2D.Force);     
    }

    private void HandleRotation()
    {
        _rotationVector = _rotationInputAction.ReadValue<Vector2>();
    }

    private void HandleRotationPhysics()
    {
        _rigidbody.MoveRotation(_rigidbody.rotation + -_rotationVector.x * _rotationSpeed * Time.fixedDeltaTime);
    }


}
