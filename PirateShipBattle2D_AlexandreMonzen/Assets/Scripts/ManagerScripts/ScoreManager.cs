using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ScoreManager : MonoBehaviour
{
    public static ScoreManager SharedInstance;
    private int _totalScore;
    
    [SerializeField] private Text _scoreText;
    [SerializeField] private string _defaultText;

    public int totalScore { get => _totalScore; }

    private void Awake()
    {
        SharedInstance = this;
        _totalScore = 0;
        UpdateScore(0);
    }

    public void UpdateScore(int scoreToAdd)
    {
        _totalScore += scoreToAdd;
        _scoreText.text = _defaultText + _totalScore.ToString();
    }
}
