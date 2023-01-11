using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class RoundManager : MonoBehaviour
{
    [SerializeField] private float _gameSessionTime;
    [SerializeField] private float _enemySpawnTime;
    [SerializeField] private bool _usePlayerPref;

    [SerializeField] private Transform[] _spawnPoints;
    private int _shipRandom;
    private GameObject shipRandom;

    private float _timerEnemySpawn;

    [SerializeField] private GameObject _timeOverUI;
    [SerializeField] private Text _sessionTimeLeft;

    private void Awake()
    {
        if (_usePlayerPref)
        {
            _gameSessionTime = PlayerPrefs.GetInt("GameSessionTime", 2);
            _gameSessionTime *= 60;

            _enemySpawnTime = PlayerPrefs.GetFloat("EnemySpawnTime", 5f);
        }
    }

    private void Update()
    {
        _gameSessionTime -= 1 * Time.deltaTime;

        if(_gameSessionTime > 0)
        {
            _timerEnemySpawn += 1 * Time.deltaTime;

            if (_timerEnemySpawn >= _enemySpawnTime)
            {
                _timerEnemySpawn = 0;
                SpawnEnemy();
            }

            _sessionTimeLeft.text = "Timer: " +  Mathf.Floor(_gameSessionTime / 60).ToString("00") + ":" + (_gameSessionTime % 60).ToString("00");
        }
        else
        {
            Time.timeScale = 0;
            _timeOverUI.SetActive(true);
            _sessionTimeLeft.text = "Timer: 00:00";
        }
    }

    private void SpawnEnemy()
    {
        _shipRandom = Random.Range(0, 101);

        if(_shipRandom < 50)
        {
            shipRandom = ObjectPooler.SharedInstance.GetPooledEnemySeeker();
            
        }
        else
        {
            shipRandom = ObjectPooler.SharedInstance.GetPooledEnemyShooter();
        }

        shipRandom.transform.position = _spawnPoints[RandomSpawnPoint()].transform.position;
        shipRandom.transform.rotation = _spawnPoints[RandomSpawnPoint()].transform.rotation;
        shipRandom.SetActive(true);
    }

    private int RandomSpawnPoint()
    {
        return Random.Range(0, _spawnPoints.Length);
    }
}
