using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resetter : MonoBehaviour
{
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            PlayerPrefs.SetInt("coins", 0);
            PlayerPrefs.SetInt("maxScore", 0);
            PlayerPrefs.SetInt("selectedSkin", 0);
        }
    }
}
