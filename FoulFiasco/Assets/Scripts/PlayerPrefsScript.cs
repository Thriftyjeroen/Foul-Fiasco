using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScirpt : MonoBehaviour
{
    void Start()//this script will check if the playerpres Coins and HighScore exist, if not than it wil be decleared with its starting values
    {
        if (!PlayerPrefs.HasKey("Coins"))
        { PlayerPrefs.SetInt("Coins", 3); }
        if (!PlayerPrefs.HasKey("HighScore"))
        { PlayerPrefs.SetFloat("HighScore", 0f); }
    }
}
