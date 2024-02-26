using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class SetCoin : MonoBehaviour
{
    public int coinAmount;
    public int coins;
    [SerializeField]
    private TextMeshProUGUI coinsText;

    private void Start()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinAmount = PlayerPrefs.GetInt("coinAmount");
        //Debug.Log("Coins statue 1: " + coins);
    }

    public void SetCoinAmount(int level)
    {
        PlayerPrefs.SetInt("coinAmount", level);
        coinAmount = PlayerPrefs.GetInt("coinAmount");
    }

    public void AdjustCoin()
    {
        PlayerPrefs.SetInt("coins", coins + coinAmount);
        coins = PlayerPrefs.GetInt("coins");
    }

    public void DisplayCoin()
    {
        coins = PlayerPrefs.GetInt("coins");
        coinsText.text = coins.ToString();
    }
}
