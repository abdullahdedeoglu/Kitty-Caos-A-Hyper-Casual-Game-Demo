using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class StoreManager : MonoBehaviour
{
    //Variables for feelings...
    private int playerMoney;
    //[SerializeField] private GameObject shop;

    //Variables For Coin
    [Header("Coin Variables")]
    private int coinPrice;
    private int coinLevel;
    public SetCoin setCoin;
    public TextMeshProUGUI coinShopText;

    //Variables Need For Speed
    private int speedPrice;
    private int speedLevel;
    public SimpleTouchToMove smp;
    public TextMeshProUGUI speedShopText;

    //Variables Time In A Bottle
    private int timePrice;
    private int timeLevel;
    public GameManager gameManager;
    public TextMeshProUGUI timeShopText;

    private void Awake()
    {
        playerMoney = PlayerPrefs.GetInt("coins");

        coinLevel = PlayerPrefs.GetInt("coinLevel");
        coinPrice = PlayerPrefs.GetInt("coinPrice");

        speedLevel = PlayerPrefs.GetInt("speedLevel");
        speedPrice = PlayerPrefs.GetInt("speedPrice");

        timeLevel = PlayerPrefs.GetInt("timeLevel");
        timePrice = PlayerPrefs.GetInt("timePrice");


        if (coinLevel == 0) SetCoinLevel();
        if (coinPrice == 0) SetCoinPrice();

        if (speedLevel == 0) SetSpeedLevel();
        if (speedPrice == 0) SetSpeedPrice();

        if (timeLevel == 0) SetTimeLevel();
        if (timePrice == 0) SetTimePrice();
    }
    private void Update()
    {
        coinShopText.text = "Coins\n" + "Level " + coinLevel + "\n" + coinPrice + "$";
        setCoin.DisplayCoin();
    }
    private void SetCoinLevel()
    {
        coinLevel = PlayerPrefs.GetInt("coinLevel", 1);
        setCoin.SetCoinAmount(coinLevel);
    }
    private void SetCoinPrice()
    {
        coinPrice = PlayerPrefs.GetInt("coinPrice", 10);
    }
    private void SetSpeedLevel()
    {
        speedLevel = PlayerPrefs.GetInt("speedLevel", 1);
    }
    private void SetSpeedPrice()
    {
        speedPrice = PlayerPrefs.GetInt("speedPrice", 10);
    }
    private void SetTimeLevel()
    {
        timeLevel = PlayerPrefs.GetInt("timeLevel", 1);
    }
    private void SetTimePrice()
    {
        timePrice = PlayerPrefs.GetInt("timePrice", 10);
    }
    public void CoinShopping()
    {
        if (playerMoney > coinPrice)
        {
            playerMoney -= coinPrice;
            PlayerPrefs.SetInt("coins", playerMoney);

            coinPrice += coinLevel * 10;
            PlayerPrefs.SetInt("coinPrice", coinPrice);

            coinLevel++;
            PlayerPrefs.SetInt("coinLevel", coinLevel);
            setCoin.SetCoinAmount(coinLevel);
        }
        coinShopText.text = "Coins\n" + "Level " + coinLevel + "\n" + coinPrice + "$";
        setCoin.DisplayCoin();
    }
    public void SpeedShopping()
    {
        if (playerMoney > speedPrice)
        {
            playerMoney -= speedPrice;
            PlayerPrefs.SetInt("coins", playerMoney);

            speedPrice += speedLevel * 10;
            PlayerPrefs.SetInt("speedPrice", speedPrice);

            speedLevel++;
            PlayerPrefs.SetInt("speedLevel", speedLevel);

            smp.speed=smp.speed * 1.5f;
            PlayerPrefs.SetFloat("speed", smp.speed);
            smp.setSpeed();
        }
        speedShopText.text = "Speed\n" + "Level " + speedLevel + "\n" + speedPrice + "$";
    }
    public void TimeShopping()
    {
        if (playerMoney > timePrice)
        {
            playerMoney -= timePrice;
            PlayerPrefs.SetInt("coins", playerMoney);

            timePrice += timeLevel * 10;
            PlayerPrefs.SetInt("timePrice", timePrice);

            timeLevel++;
            PlayerPrefs.SetInt("timeLevel", timeLevel);

            gameManager.timerValue += 10;
            PlayerPrefs.SetInt("timerValue", gameManager.timerValue);
            gameManager.SetTimerVaue();
        }
        timeShopText.text = "Time\n" + "Level " + timeLevel + "\n" + timePrice + "$";
    }
}
