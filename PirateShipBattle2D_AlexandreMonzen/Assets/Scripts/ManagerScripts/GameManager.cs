using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public sealed class GameManager : MonoBehaviour
{
    private PlayerInputActions _playerInputActions;
    private InputAction _generalInputAction;

    [SerializeField] private bool _inGameScene;

    private void Awake()
    {
        UnpauseGame();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        Time.timeScale = 1;
    }

    public void ReloadScene()
    {
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    public void LoadScene(int i)
    {
        SceneManager.LoadScene(i);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ToogleObject(GameObject gameObject)
    {
        if (gameObject.activeSelf)
        {
            gameObject.SetActive(false);
        }
        else
        {
            gameObject.SetActive(true);
        }
    }

    public void SetGameSessionTime(float minutes)
    {
        PlayerPrefs.SetInt("GameSessionTime", (int)minutes);
    }
    public void SetEnemySpawnTime(float timeToSpawnEnemy)
    {
        PlayerPrefs.SetFloat("EnemySpawnTime", timeToSpawnEnemy);
    }

}
