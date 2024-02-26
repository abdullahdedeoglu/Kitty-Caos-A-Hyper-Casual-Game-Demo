using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DayManager : MonoBehaviour
{
    System.DateTime startDate;
    System.DateTime today;

    private void Awake()
    {
        SetStartDate();
        CalculatePlayedDay();
    }

    private void SetStartDate()
    {
        if (PlayerPrefs.HasKey("startDate"))
            startDate = System.Convert.ToDateTime(PlayerPrefs.GetString("StartDate"));
        else
        {
            startDate=System.DateTime.Now;
            PlayerPrefs.SetString("StartDate", startDate.ToString());
        }
    }

    private void CalculatePlayedDay()
    {
        today = System.DateTime.Now;
        System.TimeSpan elapsed = today.Subtract(startDate);
        double days = elapsed.TotalDays;
        PlayerPrefs.SetInt("DaysPlayed", int.Parse(days.ToString("0")));
    }
}
