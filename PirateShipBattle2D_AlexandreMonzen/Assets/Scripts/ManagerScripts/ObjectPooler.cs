using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class ObjectPooler : MonoBehaviour
{
    public static ObjectPooler SharedInstance;
    [SerializeField] private GameObject _player;

    private List<GameObject> _pooledShipExplosion;
    private List<GameObject> _pooledCannonBallExplosion;
    private List<GameObject> _pooledUpPlayerCannonBall;
    private List<GameObject> _pooledRigthPlayerCannonBall;
    private List<GameObject> _pooledLeftPlayerCannonBall;
    private List<GameObject> _pooledUpEnemyCannonBall;
    private List<GameObject> _pooledEnemySeeker;
    private List<GameObject> _pooledEnemyShooter;

    [Header("General Prefabs")]
    [SerializeField] private GameObject _shipExplosionObj;
    [SerializeField] private GameObject _cannonBallExplosionObj;

    [Header("Player Cannon Ball Prefabs")]
    [SerializeField] private GameObject _upPlayerCannonBallObj;
    [SerializeField] private GameObject _rigthPlayerCannonBallObj;
    [SerializeField] private GameObject _leftPlayerCannonBallObj;

    [Header("Enemies Cannon Ball Prefabs")]
    [SerializeField] private GameObject _upEnemyCannonBallObj;

    [Header("Enemies Prefabs")]
    [SerializeField] private GameObject _enemySeekerObj;
    [SerializeField] private GameObject _enemyShooterObj;

    [Header("General Amount")]
    [SerializeField] private int _amountShipExplosion;
    [SerializeField] private int _amountCannonBallExplosion;

    [Header("Player Cannon Ball Amount")]
    [SerializeField] private int _amountUpPlayerCannonBall;
    [SerializeField] private int _amountRigthPlayerCannonBall;
    [SerializeField] private int _amountLeftPlayerCannonBall;

    [Header("Enemies Cannon Ball Amount")]
    [SerializeField] private int _amountUpEnemyCannonBall;

    [Header("Enemies Prefabs Amount")]
    [SerializeField] private int _amountEnemySeeker;
    [SerializeField] private int _amountEnemyShooter;


    private void Awake()
    {
        SharedInstance = this;

        _pooledShipExplosion = new List<GameObject>();
        for (int i = 0; i < _amountShipExplosion; i++)
        {
            GameObject obj = Instantiate(_shipExplosionObj);
            obj.SetActive(false);
            _pooledShipExplosion.Add(obj);
        }

        _pooledCannonBallExplosion = new List<GameObject>();
        for (int i = 0; i < _amountCannonBallExplosion; i++)
        {
            GameObject obj = Instantiate(_cannonBallExplosionObj);
            obj.SetActive(false);
            _pooledCannonBallExplosion.Add(obj);
        }

        _pooledUpPlayerCannonBall = new List<GameObject>();
        for (int i = 0; i < _amountUpPlayerCannonBall; i++)
        {
            GameObject obj = Instantiate(_upPlayerCannonBallObj);
            obj.SetActive(false);
            _pooledUpPlayerCannonBall.Add(obj);
        }

        _pooledRigthPlayerCannonBall = new List<GameObject>();
        for (int i = 0; i < _amountRigthPlayerCannonBall; i++)
        {
            GameObject obj = Instantiate(_rigthPlayerCannonBallObj);
            obj.SetActive(false);
            _pooledRigthPlayerCannonBall.Add(obj);
        }

        _pooledLeftPlayerCannonBall = new List<GameObject>();
        for (int i = 0; i < _amountLeftPlayerCannonBall; i++)
        {
            GameObject obj = Instantiate(_leftPlayerCannonBallObj);
            obj.SetActive(false);
            _pooledLeftPlayerCannonBall.Add(obj);
        }

        _pooledUpEnemyCannonBall = new List<GameObject>();
        for (int i = 0; i < _amountUpEnemyCannonBall; i++)
        {
            GameObject obj = Instantiate(_upEnemyCannonBallObj);
            obj.SetActive(false);
            _pooledUpEnemyCannonBall.Add(obj);
        }

        _pooledEnemySeeker = new List<GameObject>();
        for (int i = 0; i < _amountEnemySeeker; i++)
        {
            GameObject obj = Instantiate(_enemySeekerObj);
            EnemyBehaviour enemyBehaviour = obj.GetComponent<EnemyBehaviour>();
            enemyBehaviour.targetToSeek = _player;
            obj.SetActive(false);
            _pooledEnemySeeker.Add(obj);
        }

        _pooledEnemyShooter = new List<GameObject>();
        for (int i = 0; i < _amountEnemyShooter; i++)
        {
            GameObject obj = Instantiate(_enemyShooterObj);
            EnemyBehaviour enemyBehaviour = obj.GetComponent<EnemyBehaviour>();
            enemyBehaviour.targetToSeek = _player;
            obj.SetActive(false);
            _pooledEnemyShooter.Add(obj);
        }
    }

    public GameObject GetPooledShipExplosion()
    {
        for (int i = 0; i < _pooledShipExplosion.Count; i++)
        {
            if (!_pooledShipExplosion[i].activeInHierarchy)
            {
                return _pooledShipExplosion[i];
            }
        }
        return null;
    }

    public GameObject GetPooledCannonBallExplosion()
    {
        for (int i = 0; i < _pooledCannonBallExplosion.Count; i++)
        {
            if (!_pooledCannonBallExplosion[i].activeInHierarchy)
            {
                return _pooledCannonBallExplosion[i];
            }
        }
        return null;
    }

    public GameObject GetPooledUpPlayerCannonBall()
    {
        for (int i = 0; i < _pooledUpPlayerCannonBall.Count; i++)
        {
            if (!_pooledUpPlayerCannonBall[i].activeInHierarchy)
            {
                return _pooledUpPlayerCannonBall[i];
            }
        }
        return null;
    }

    public GameObject GetPooledRigthPlayerCannonBall()
    {
        for (int i = 0; i < _pooledRigthPlayerCannonBall.Count; i++)
        {
            if (!_pooledRigthPlayerCannonBall[i].activeInHierarchy)
            {
                return _pooledRigthPlayerCannonBall[i];
            }
        }
        return null;
    }

    public GameObject GetPooledLeftPlayerCannonBall()
    {
        for (int i = 0; i < _pooledLeftPlayerCannonBall.Count; i++)
        {
            if (!_pooledLeftPlayerCannonBall[i].activeInHierarchy)
            {
                return _pooledLeftPlayerCannonBall[i];
            }
        }
        return null;
    }

    public GameObject GetPooledUpEnemyCannonBall()
    {
        for (int i = 0; i < _pooledUpEnemyCannonBall.Count; i++)
        {
            if (!_pooledUpEnemyCannonBall[i].activeInHierarchy)
            {
                return _pooledUpEnemyCannonBall[i];
            }
        }
        return null;
    }

    public GameObject GetPooledEnemySeeker()
    {
        for (int i = 0; i < _pooledEnemySeeker.Count; i++)
        {
            if (!_pooledEnemySeeker[i].activeInHierarchy)
            {
                return _pooledEnemySeeker[i];
            }
        }
        return null;
    }

    public GameObject GetPooledEnemyShooter()
    {
        for (int i = 0; i < _pooledEnemyShooter.Count; i++)
        {
            if (!_pooledEnemyShooter[i].activeInHierarchy)
            {
                return _pooledEnemyShooter[i];
            }
        }
        return null;
    }
}

