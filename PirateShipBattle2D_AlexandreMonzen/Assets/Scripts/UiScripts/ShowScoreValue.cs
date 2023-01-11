using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public sealed class ShowScoreValue : MonoBehaviour
{
    private Text _textScore;

    private void Awake()
    {
        _textScore = GetComponent<Text>();
    }

    private void OnEnable()
    {
        _textScore.text = ScoreManager.SharedInstance.totalScore.ToString();
    }
}
