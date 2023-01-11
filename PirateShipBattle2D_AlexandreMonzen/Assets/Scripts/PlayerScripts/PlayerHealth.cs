using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class PlayerHealth : Health
{
    [SerializeField] private GameObject _gameOverUI;

    protected override void Die()
    {
        base.Die();
        Time.timeScale = 0;
        _gameOverUI.SetActive(true);
    }
}
