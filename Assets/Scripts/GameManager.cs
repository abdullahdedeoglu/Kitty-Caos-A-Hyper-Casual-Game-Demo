using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    //Level Variables
    [SerializeField] private int level = 1;
    [SerializeField] private GameObject[] rooms;

    //Screen variables
    public bool gameStarted = false;
    public bool gameEnded = false;
    [SerializeField] private GameObject[] tutorials;

    [SerializeField] private GameObject endScreen;
    [SerializeField] private SetScore setScore;
    [SerializeField] private SetCoin setCoin;
    
    [SerializeField] private TextMeshProUGUI timerText;
    public int timerValue = 30;

    public EnemyCatAI[] enemies;

    private void Awake()
    {
        setScore.DisplayMaxScore();
        setCoin.DisplayCoin();
        
        for (int i = 1; i < rooms.Length; i++)
        {
            if(i <= level)
            {
                rooms[i-1].SetActive(true);
            }
        }
    }

    public void GameStarter()
    {
        if (!gameStarted)
        {
            gameStarted = true;
            tutorials[0].SetActive(false);
            SetTimerVaue();
            InvokeRepeating("SetTimer", 1, 1);
            foreach (EnemyCatAI enemy in enemies)
            {
                enemy.StartGame();
            }
        }
    }

    public void RestartGame()
    {
        
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void SetTimer()
    {
        timerValue--;
        timerText.text = timerValue.ToString();
        if (timerValue == 0)
        {
            GameOver();
        }
    }

    public void GameOver()
    {
        gameEnded = true;
        CancelInvoke();
        endScreen.SetActive(true);
        setScore.SetFinalScore();
        setScore.SetMaxScore();
        setScore.CompareScores();
    }

    public void WatchAdvertise()
    {
        GetExtraTime();
    }

    public void GetExtraTime()
    {
        timerValue = 5;
        timerText.text = timerValue.ToString();
        gameEnded = false;
        endScreen.SetActive(false);
        InvokeRepeating("SetTimer", 1, 1);
    }

    public void SetTimerVaue()
    {
        timerValue = PlayerPrefs.GetInt("timerValue", timerValue);
    }
}
