using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public sealed class PlayerAttack : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;

    [SerializeField] private Transform[] _offsetCannons;

    [SerializeField] private float _timeToShootSingle;
    [SerializeField] private float _timeToShootMultiple;

    private float _timerShootSingle;
    private float _timerShootMultiple;

    [SerializeField] string _pathShootCannonBall;

    private void Awake()
    {
        _playerInputActions = new PlayerInputActions();
    }

    private void Update()
    {
        _timerShootSingle += 1 * Time.deltaTime;
        _timerShootMultiple += 1 * Time.deltaTime;
    }

    private void OnEnable()
    {
        _playerInputActions.Player.AttackSingleShoot.Enable();
        _playerInputActions.Player.AttackSingleShoot.performed += DoAttackSingleShoot;

        _playerInputActions.Player.AttackMultipleShoot.Enable();
        _playerInputActions.Player.AttackMultipleShoot.performed += DoAttackMultipleShoot;
    }

    private void OnDisable()
    {
        _playerInputActions.Player.AttackSingleShoot.performed -= DoAttackSingleShoot;
        _playerInputActions.Player.AttackSingleShoot.Disable();

        _playerInputActions.Player.AttackMultipleShoot.performed -= DoAttackMultipleShoot;
        _playerInputActions.Player.AttackMultipleShoot.Disable();
    }

    private void DoAttackSingleShoot(InputAction.CallbackContext obj)
    {
        if (_timerShootSingle >= _timeToShootSingle)
        {
            _timerShootSingle = 0;

            GameObject cannonBall = ObjectPooler.SharedInstance.GetPooledUpPlayerCannonBall();
            cannonBall.transform.position = _offsetCannons[0].position;
            cannonBall.transform.rotation = _offsetCannons[0].rotation;
            cannonBall.SetActive(true);
            FMODUnity.RuntimeManager.PlayOneShot(_pathShootCannonBall);
        }
    }

    private void DoAttackMultipleShoot(InputAction.CallbackContext obj)
    {
        if (_timerShootMultiple >= _timeToShootMultiple)
        {
            _timerShootMultiple = 0;

            GameObject cannonBall_1 = ObjectPooler.SharedInstance.GetPooledLeftPlayerCannonBall();
            cannonBall_1.transform.position = _offsetCannons[1].position;
            cannonBall_1.transform.rotation = _offsetCannons[1].rotation;
            cannonBall_1.SetActive(true);
            FMODUnity.RuntimeManager.PlayOneShot(_pathShootCannonBall);

            GameObject cannonBall_2 = ObjectPooler.SharedInstance.GetPooledRigthPlayerCannonBall();
            cannonBall_2.transform.position = _offsetCannons[2].position;
            cannonBall_2.transform.rotation = _offsetCannons[2].rotation;
            cannonBall_2.SetActive(true);
            FMODUnity.RuntimeManager.PlayOneShot(_pathShootCannonBall);
        }
    }
}
