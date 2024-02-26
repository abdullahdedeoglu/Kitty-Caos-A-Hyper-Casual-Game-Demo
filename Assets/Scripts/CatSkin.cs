using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSkin : MonoBehaviour
{
    [SerializeField] private Texture[] skins;
    [SerializeField] private Material catMaterial;
    public int selectedSkin;

    private void Awake()
    {
        selectedSkin = PlayerPrefs.GetInt("selectedSkin", 0);
        catMaterial.mainTexture = skins[selectedSkin];

    }

    public void SetSkin(int skinID)
    {
        catMaterial.mainTexture = skins[skinID];
    }
}
