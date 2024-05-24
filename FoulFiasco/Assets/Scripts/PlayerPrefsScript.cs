using UnityEngine;

public class PlayerPrefsScirpt : MonoBehaviour
{
    void Awake()//this script will check if the playerprefs exist , if not than it wil be decleared with its starting values
    {
        if (!PlayerPrefs.HasKey("Coins")) PlayerPrefs.SetInt("Coins", 5);
        if (!PlayerPrefs.HasKey("HighScore")) PlayerPrefs.SetFloat("HighScore", 0f);
        if (!PlayerPrefs.HasKey("Running")) PlayerPrefs.SetString("Running","false");
    }
}
