using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemUnlocker : MonoBehaviour
{
    public int daysPlayed;
    public Button skin1Button;

    private void Start()
    {
        daysPlayed = PlayerPrefs.GetInt("DaysPlayed");

        if (daysPlayed >= 3)
        {
            PlayerPrefs.SetInt("Skin1_Unlocked", 1);
            skin1Button.interactable = true;
        }
    }
}
