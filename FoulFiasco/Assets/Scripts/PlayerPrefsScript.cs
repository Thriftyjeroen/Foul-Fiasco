using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsScirpt : MonoBehaviour
{
    void Start()//het nut van deze script is om bij het starten van de scene dat er word gekeken of de keys Coins en HighScore bestaat zo niet dan word die gemaakt met de bijbehorende waardes
    {
        if (PlayerPrefs.HasKey("Coins"))
        { PlayerPrefs.SetInt("Coins", 3); }
        if (PlayerPrefs.HasKey("HighScore"))
        { PlayerPrefs.SetFloat("HighScore", 0f); }
    }
}
