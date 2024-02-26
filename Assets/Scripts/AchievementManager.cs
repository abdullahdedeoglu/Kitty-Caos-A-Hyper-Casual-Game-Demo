using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AchievementManager : MonoBehaviour
{
    //TODO
    //In here, with basic coding i'll put a achievement system that,
    //whenever player success a task, buttons will be interactive and
    //players can collect prizes, because of it's a continuing in real
    //time process, i decided to doesn't make them. Just for an example
    //i'll make "Collect 100 Coins" achievement is reachable. 
    
    public Button button;
    public Image image;
    private int coins;
    public int isClicked;
    void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        isClicked = PlayerPrefs.GetInt("isClicked", 0);
        image.enabled = false;
        
    }

    private void Update()
    {
        CheckAchievement();
    }

    private void CheckAchievement()
    {
        if (coins >= 100 && isClicked == 0)
        {
            button.interactable = true;
            image.enabled = true;
        }
    }

    public void CoinMission()
    {
        isClicked = 1;
        PlayerPrefs.SetInt("isClicked", 1);
        coins += 100;
        PlayerPrefs.SetInt("coins", coins);
        button.interactable = false;
    }
}
