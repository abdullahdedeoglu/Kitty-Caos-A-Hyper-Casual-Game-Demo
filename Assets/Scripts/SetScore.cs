using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetScore : MonoBehaviour
{
    [SerializeField] private int points = 50;
    private int score;
    private int finalScore;
    private int maxScore;
    [SerializeField] private TextMeshProUGUI scoreText;
    [SerializeField] private TextMeshProUGUI finalScoreText;
    [SerializeField] private TextMeshProUGUI maxScoreText;
    [SerializeField] private TextMeshProUGUI enemyScoreText;
    [SerializeField] private TextMeshProUGUI winnerText;

    private void Awake()
    {
        score = 0;
    }

    public void AdjustScore()
    {
        score += points;
        WriteScore();
    }

    public void WriteScore()
    {
        scoreText.text = score.ToString();
    }

    public void SetFinalScore()
    {
        finalScore = score;
        finalScoreText.text = "Score: " + finalScore.ToString();
    }

    public void SetMaxScore()
    {
        maxScore=PlayerPrefs.GetInt("maxScore");
        
        if (finalScore > maxScore)
        {
            PlayerPrefs.SetInt("maxScore", finalScore);          
        }
    }

    public void DisplayMaxScore()
    {
        int displayScore = PlayerPrefs.GetInt("maxScore");
        maxScoreText.text = "Best: " + displayScore;
    }

    public void CompareScores()
    {
        Debug.Log("What da hell is goin on");
        int enemyScore = PlayerPrefs.GetInt("EnemyScore");
        enemyScoreText.text = "Enemy Score: " + enemyScore;

        if (enemyScore > score)
        {
            winnerText.text = "You Lost";
        }
        else
        {
            winnerText.text = "You Win!";

        }
    }
}
