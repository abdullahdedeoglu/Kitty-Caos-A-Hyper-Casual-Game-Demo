using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinSelector : MonoBehaviour
{
    [SerializeField] private GameObject shop;
    [SerializeField] private CatSkin cs;
    public void SelectSkin(int skinID)
    {
        PlayerPrefs.SetInt("selectedSkin", skinID);
        //Debug.Log("Selected skin: " + skinID);
        cs.SetSkin(skinID);
        shop.SetActive(false);
    }
}
