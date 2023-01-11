using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class Explosion : MonoBehaviour
{
    [SerializeField] private string _pathCannonBallExplosion;
    private bool _gameStarted;

    private void Awake()
    {
        _gameStarted = false;
    }

    private void OnEnable()
    {
        if (_gameStarted)
        {
            FMODUnity.RuntimeManager.PlayOneShot(_pathCannonBallExplosion, this.transform.position);
        }
    }

    private void Start()
    {
        _gameStarted = true;
    }

    private void DeactiveObject()
    {
        gameObject.SetActive(false);
    }
}
